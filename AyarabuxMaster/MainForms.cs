using AyarabuxMaster.Helpers;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace AyarabuxMaster
{
    public partial class MainForms : Form
    {
        /// <summary>
        /// 遊戲網址
        /// </summary>
        public readonly string gameUrl = "http://pc-play.games.dmm.co.jp/play/Ayarabux/";

        public ChromiumWebBrowser mainWeb;

        public string Email { get; set; } = "";
        public string Password { get; set; } = "";

        private bool loginSubmitted, styleSheetApplied;
        private string resultURL;

        public MainForms()
        {
            InitializeComponent();
            InitBrowser();

            MiscHelper.main = this;
        }

        /// <summary>
        /// 初始化ChromiumWebBrowser
        /// </summary>
        private void InitBrowser()
        {
            mainWeb = new ChromiumWebBrowser("about:blank");
            BrowserSettings config = new BrowserSettings();

            config.FileAccessFromFileUrls = CefState.Disabled;
            config.UniversalAccessFromFileUrls = CefState.Disabled;
            config.WebSecurity = CefState.Enabled;
            config.WebGl = CefState.Enabled;
            config.ApplicationCache = CefState.Enabled;
            config.WindowlessFrameRate = 60;

            mainWeb.BrowserSettings = config;
            mainWeb.MenuHandler = new CefHandler.MenuHandler();
            mainWeb.AllowDrop = false;
            mainWeb.FrameLoadEnd += mainWeb_FrameLoadEnd;
            mainWeb.IsBrowserInitializedChanged += MainWeb_IsBrowserInitializedChanged;

            panel1.Controls.Add(mainWeb);
        }


        private void btn_Capture_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Screenshot_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".png";
            MiscHelper.CaptureScreen(mainWeb, path);
        }

        private void btn_Click_Click(object sender, EventArgs e)
        {
            timerAuto.Enabled = !timerAuto.Enabled;
            if (timerAuto.Enabled) btn_Click.Text = "取消點";
            else btn_Click.Text = "點";
        }

        private void MainForms_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mainWeb.GetBrowser().CloseBrowser(true);
                Cef.Shutdown();
            }
            catch (Exception) { }

            Environment.Exit(0);
        }

        private void btn_TopMost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            if (TopMost) btn_TopMost.Text = "取消置頂";
            else btn_TopMost.Text = "置頂";
        }

        private void btn_Dev_Click(object sender, EventArgs e)
        {
            mainWeb.ShowDevTools();
        }
        
        private async void mainWeb_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (styleSheetApplied || e.HttpStatusCode != 200) return;

            //取得遊戲外連連結
            if (e.Url == gameUrl)
            {
                resultURL = (await mainWeb.EvaluateScriptAsync("document.getElementById('game_frame').getAttribute('src');")).Result.ToString();
                mainWeb.ExecuteScriptAsync("document.location = document.getElementById('game_frame').getAttribute('src');");
            }

            //設定CSS
            if (e.Url == resultURL)
            {
                mainWeb.GetMainFrame().ExecuteJavaScriptAsync("var style = document.createElement('style');");
                mainWeb.GetMainFrame().ExecuteJavaScriptAsync("style.innerHTML = 'body { overflow:hidden; }'");
                mainWeb.GetMainFrame().ExecuteJavaScriptAsync("document.head.appendChild(style);");

                styleSheetApplied = true;
            }

            //自動登入相關
            if (!loginSubmitted)
            {
                if (Email != "" && Password != "")
                {
                    mainWeb.ExecuteScriptAsync($"document.getElementById('login_id').value = '{Email}'");
                    mainWeb.ExecuteScriptAsync($"document.getElementById('password').value = '{Password}'");

                    mainWeb.ExecuteScriptAsync("[...document.getElementsByTagName('input')].forEach((item) => { if (item.type == 'submit') item.click(); });");
                }

                loginSubmitted = true;
            }
        }

        private void MainWeb_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            if (mainWeb.IsBrowserInitialized)
            {
                //顯示登入視窗
                Invoke(new Action(() => { new LoginForms() { Owner = this }.ShowDialog(); }));
            }
        }

        private void timerAuto_Tick(object sender, EventArgs e)
        {
            //座標指定無用，只會跟著游標點擊
            MiscHelper.MouseLeftClick(600, 600);
        }
    }
}
