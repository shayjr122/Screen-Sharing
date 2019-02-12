using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ScreenSetting
{
    static class Screen
    {

        // print screen to Bitmap
        public static Bitmap Shot()
        {
            Bitmap screenshot = new Bitmap((int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight,
            System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(screenshot as System.Drawing.Image);
            g.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
            return screenshot;
        }
    }
}
