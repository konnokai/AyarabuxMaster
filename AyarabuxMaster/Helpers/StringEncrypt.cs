using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AyarabuxMaster
{
    public static class StringEncrypt
    {
        /// <summary>
        /// 帳號儲存路徑
        /// </summary>
        public static string UserDataPath { get { return AppDomain.CurrentDomain.BaseDirectory + "UserData.dat"; } }

        /// <summary>
        /// 字串加密(非對稱式)
        /// </summary>
        /// <param name="Source">加密前字串</param>
        /// <param name="CryptoKey">加密金鑰</param>
        /// <returns>加密後字串</returns>
        public static string AesEncryptBase64(string SourceStr, string CryptoKey)
        {
            string encrypt = "";

            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                aes.Key = key;
                aes.IV = iv;

                byte[] dataByteArray = Encoding.UTF8.GetBytes(SourceStr);
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return encrypt;
        }

        /// <summary>
        /// 字串解密(非對稱式)
        /// </summary>
        /// <param name="Source">解密前字串</param>
        /// <param name="CryptoKey">解密金鑰</param>
        /// <returns>解密後字串</returns>
        public static string AesDecryptBase64(string SourceStr, string CryptoKey)
        {
            string decrypt = "";

            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
                aes.Key = key;
                aes.IV = iv;

                byte[] dataByteArray = Convert.FromBase64String(SourceStr);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

            return decrypt;
        }

        /// <summary>
        /// 保存使用者帳號資料
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">密碼</param>
        public static void SaveUserData(string email, string password)
        {
            File.WriteAllText(UserDataPath, AesEncryptBase64(email + " " + password, "Create_by_jun"));
        }

        /// <summary>
        /// 載入已儲存的使用者帳號
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public static bool LoadUserData(out string email, out string password)
        {
            email = ""; password = "";

            if (!File.Exists(UserDataPath)) return false;

            try
            {
                string[] text = AesDecryptBase64(File.ReadAllText(UserDataPath), "Create_by_jun").Split(new char[] { ' ' });
                email = text[0];
                password = text[1];
            }
            catch (Exception)
            { 
                File.Delete(UserDataPath);
                return false;
            }

            return true;
        }
    }
}
