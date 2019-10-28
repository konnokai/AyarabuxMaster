using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace AyarabuxMaster
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CefSettings settings = new CefSettings();

            settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.1.142.0 Safari/537.36";
            settings.IgnoreCertificateErrors = true;
            settings.LogSeverity = LogSeverity.Disable;
            settings.CachePath = @"C:\ProgramData\AyarabuxMaster\Cache";
            //CefSharpSettings.Proxy = new ProxyOptions("127.0.0.1", DataUtil.Config.localProxyPort.ToString());

            Cef.Initialize(settings);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForms());
        }
    }
}
