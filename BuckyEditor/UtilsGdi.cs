using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BuckyEditor
{
    public static class UtilsGDI
    {
        public static Image ResizeBitmap(Image image, int width, int height)
        {
            if ((image.Width == width) && (image.Height == height))
            {
                return image;
            }
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            try
            {
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            }
            catch (ArgumentException ex)
            {
                //exception throw on Mono.
            }

            using (var graphics = Graphics.FromImage(destImage))
            {
                /*graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;*/

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        //glue image together
        public static Bitmap GlueImages(Image[] images, int width, int height)
        {
            int totalImageWidth = 0;
            int totalImageHeight = 0;
            for (int x = 0; x < width; x++)
            {
                totalImageWidth += images[x].Width;
            }
            for (int y = 0; y < height; y++)
            {
                totalImageHeight += images[y * width].Height;
            }

            var totalImage = new Bitmap(totalImageWidth, totalImageHeight);
            using (var g = Graphics.FromImage(totalImage))
            {
                int currentY = 0;
                for (int y = 0; y < height; y++)
                {
                    int currentX = 0;
                    int currentMaxY = 0;
                    for (int x = 0; x < width; x++)
                    {
                        var imIndex = y * width + x;
                        if (imIndex < images.Length)
                        {
                            var im = images[imIndex];
                            g.DrawImage(im, new Point(currentX, currentY));
                            currentX += im.Width;
                            currentMaxY = Math.Max(currentMaxY, im.Height);
                            if (x == width - 1)
                            {
                                currentY += currentMaxY;
                            }
                        }
                    }
                }
            }
            return totalImage;
        }
    }
}
