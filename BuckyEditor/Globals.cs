using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BuckyEditor
{
    public static class Globals
    {
        static Globals()
        {
        }

        public static bool loadData(string filename, string configFilename)
        {
            try
            {
                int size = (int)new FileInfo(filename).Length;
                using (FileStream f = File.OpenRead(filename))
                {
                    romdata = new byte[size];
                    f.Read(romdata, 0, size);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load rom error");
                return false;
            }

            try
            {
                ConfigScript.LoadFromFile(configFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load config error");
                return false;
            }

            return true;
        }

        public static bool flushToFile()
        {
            try
            {
                using (FileStream f = File.OpenWrite(OpenFile.fileName))
                {
                    f.Write(Globals.romdata, 0, Globals.romdata.Length);
                    f.Seek(0, SeekOrigin.Begin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public static Screen getScreen(int screenIndex)
        {
            var result = new int[Math.Max(64, ConfigScript.screenSize)];
            var arrayWithData = Globals.romdata;
            int beginAddr = ConfigScript.levelStartAddress + screenIndex * ConfigScript.screenSize;
            for (int i = 0; i < ConfigScript.screenSize; i++)
                result[i] = arrayWithData[beginAddr + i];

            return new Screen(result, 8, ConfigScript.screenHeight);
        }

        public static byte[] romdata;
        public static int palLen = 16;

        public static Color[] mesenColors = new[] {
            Color.FromArgb(102, 102, 102),
            Color.FromArgb(0, 42, 136),
            Color.FromArgb(20, 18, 167),
            Color.FromArgb(59, 0, 164),
            Color.FromArgb(92, 0, 126),
            Color.FromArgb(110, 0, 64),
            Color.FromArgb(108, 6, 0),
            Color.FromArgb(86, 29, 0),
            Color.FromArgb(51, 53, 0),
            Color.FromArgb(11, 72, 0),
            Color.FromArgb(0, 82, 0),
            Color.FromArgb(0, 79, 8),
            Color.FromArgb(0, 64, 77),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(173, 173, 173),
            Color.FromArgb(21, 95, 217),
            Color.FromArgb(64, 64, 255),
            Color.FromArgb(117, 39, 254),
            Color.FromArgb(160, 26, 204),
            Color.FromArgb(183, 30, 123),
            Color.FromArgb(181, 49, 32),
            Color.FromArgb(153, 78, 0),
            Color.FromArgb(107, 109, 0),
            Color.FromArgb(56, 135, 0),
            Color.FromArgb(12, 147, 0),
            Color.FromArgb(0, 143, 50),
            Color.FromArgb(0, 124, 141),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(255, 254, 255),
            Color.FromArgb(100, 176, 255),
            Color.FromArgb(146, 144, 255),
            Color.FromArgb(198, 118, 255),
            Color.FromArgb(243, 106, 255),
            Color.FromArgb(254, 110, 204),
            Color.FromArgb(254, 129, 112),
            Color.FromArgb(234, 158, 34),
            Color.FromArgb(188, 190, 0),
            Color.FromArgb(136, 216, 0),
            Color.FromArgb(92, 228, 48),
            Color.FromArgb(69, 224, 130),
            Color.FromArgb(75, 205, 222),
            Color.FromArgb(79, 79, 79),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(255, 254, 255),
            Color.FromArgb(192, 223, 255),
            Color.FromArgb(211, 210, 255),
            Color.FromArgb(232, 200, 255),
            Color.FromArgb(215, 194, 255),
            Color.FromArgb(254, 196, 234),
            Color.FromArgb(254, 204, 197),
            Color.FromArgb(247, 216, 165),
            Color.FromArgb(228, 229, 148),
            Color.FromArgb(207, 239, 150),
            Color.FromArgb(189, 244, 171),
            Color.FromArgb(179, 243, 204),
            Color.FromArgb(181, 235, 242),
            Color.FromArgb(184, 184, 184),
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 0)
        };
    }
}