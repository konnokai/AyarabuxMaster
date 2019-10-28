using System;
using System.IO;
using System.Windows.Forms;

namespace AyarabuxMaster
{
    public partial class LoginForms : Form
    {
        private MainForms main = Helpers.MiscHelper.main;

        public LoginForms()
        {
            InitializeComponent();

            if (StringEncrypt.LoadUserData(out string email, out string pass))
            {
                txt_Email.Text = email;
                txt_Pass.Text = pass;
                cb_SaveAcc.Checked = true;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //若使用者輸入了帳號及密碼
            if (txt_Email.Text != "" && txt_Pass.Text != "")
            {
                main.Email = txt_Email.Text;
                main.Password = txt_Pass.Text;

                //若使用者點擊保存帳號，則保存資料
                if (cb_SaveAcc.Checked)
                {
                    StringEncrypt.SaveUserData(txt_Email.Text, txt_Pass.Text);
                }
            }

            //若未點擊保存帳號，就刪除保存資料
            if (!cb_SaveAcc.Checked && File.Exists(StringEncrypt.UserDataPath))
            {
                File.Delete(StringEncrypt.UserDataPath);
            }

            //關閉視窗並呼叫瀏覽器Load登入頁面
            Close();
        }

        private void LoginForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.mainWeb.Load(main.gameUrl);
        }
    }
}
