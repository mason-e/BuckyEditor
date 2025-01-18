using System;
using System.Drawing;

namespace CadEditor
{
    public static class VideoHelper
    {
        public static Image addObjNumber(Image source, int no)
        {
            using (Graphics g = Graphics.FromImage(source))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(192, 255, 255, 255)), new Rectangle(0, 0, source.Width, source.Height));
                g.DrawString(String.Format("{0:X}", no), new Font("Arial", source.Width / 4.0f), Brushes.Red, new Point(0, 0));
            }
            return source;
        }
    }
}
