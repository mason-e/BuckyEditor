using System;
using System.IO;
using System.Windows.Forms;

namespace CadEditor
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

        public static int readBlockIndexFromMap(byte[] arrayWithData, int romAddr, int index)
        {
            return ConfigScript.convertScreenTile(arrayWithData[romAddr + index]);
        }

        public static Screen getScreen(OffsetRec screenOffset, int screenIndex)
        {
            var result = new int[Math.Max(64, screenOffset.recSize)];
            var arrayWithData = Globals.romdata;
            int beginAddr = screenOffset.beginAddr + screenIndex * screenOffset.recSize;
            for (int i = 0; i < screenOffset.recSize; i++)
                result[i] = readBlockIndexFromMap(arrayWithData, beginAddr, i);
            //TODO: read layer2

            int w = screenOffset.width;
            int h = screenOffset.height;

            return new Screen(new BlockLayer(result), w, h);
        }

        public static byte[] romdata;
        public static int chunksCount = 256;
        public static int videoPageSize = 4096;
        public static int palLen = 16;
    }
}