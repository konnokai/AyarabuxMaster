using CefSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace AyarabuxMaster.Helpers
{
    class MiscHelper
    {
        public static MainForms main;

        /// <summary>
        /// 擷取Control的畫面到指定目錄
        /// </summary>
        /// <param name="source">Control</param>
        /// <param name="path">目錄</param>
        public static void CaptureScreen(Control source, string path)
        {
            Bitmap bm = new Bitmap(source.Width, source.Height);

            using (Graphics g = Graphics.FromImage(bm))
            {
                g.CopyFromScreen(source.PointToScreen(new Point(0, 0)), new Point(0, 0), bm.Size);
            }

            bm.Save(path, ImageFormat.Png);
            Clipboard.SetImage(bm);
        }

        /// <summary>
        /// 模擬滑鼠左鍵點擊
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public static void MouseLeftClick(int x, int y)
        {
            main.mainWeb.GetBrowser().GetHost().SendMouseClickEvent(x, y, MouseButtonType.Left, false, 1, CefEventFlags.LeftMouseButton);
            main.mainWeb.GetBrowser().GetHost().SendMouseClickEvent(x, y, MouseButtonType.Left, true, 1, CefEventFlags.LeftMouseButton);
        }
    }
}
