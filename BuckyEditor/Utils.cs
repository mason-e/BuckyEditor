using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BuckyEditor
{
    public static class Utils
    {

        public static int[] transpose(int[] matrix, int w, int h)
        {
            var result = new int[h * w];
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j * w + i] = matrix[i * h + j];
                }
            }
            return result;
        }

        public static int getBigTileNoFromScreen(int[] screenData, int index)
        {
            return screenData[index];
        }

        public static void setBigTileToScreen(int[] screenData, int index, int value)
        {
            screenData[index] = value;
        }

        public static bool getBit(byte b, int bit)
        {
            return (b & (1 << bit - 1)) != 0;
        }

        public static void swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public static ObjRec[] readBlocksLinear(byte[] romdata, int addr, int w, int h, int count, bool withAttribs, bool transposeIndexes = false, int stride = 0)
        {
            var objects = new ObjRec[count];
            int blockSize = w * h;
            int pw = (int)Math.Ceiling(w / 2.0);
            int ph = (int)Math.Ceiling(h / 2.0);
            int palSize = pw * ph;
            int fullSize = withAttribs ? blockSize + palSize : blockSize;
            for (int i = 0; i < count; i++)
            {
                var indexes = new int[blockSize];
                var palBytes = new int[palSize];
                int baseAddr = addr + i * (fullSize + stride);
                Array.Copy(romdata, baseAddr, indexes, 0, blockSize);
                if (withAttribs)
                {
                    Array.Copy(romdata, baseAddr + blockSize, palBytes, 0, palSize);
                }
                if (transposeIndexes)
                {
                    indexes = transpose(indexes, w, h);
                }

                //todo: add flag to decode or not to decode type from palBytes
                objects[i] = new ObjRec(w, h, 0, indexes, palBytes);
            }
            return objects;
        }

        public static void writeBlocksLinear(ObjRec[] objects, byte[] romdata, int addr, int count, bool withAttribs, bool transposeIndexes = false, int stride = 0)
        {
            var block0 = objects[0];
            int bw = block0.w, bh = block0.h;
            int blockSize = block0.indexes.Length;
            int palSize = block0.palBytes.Length;
            int fullSize = blockSize + (withAttribs ? palSize : 0);
            for (int i = 0; i < count; i++)
            {
                var obj = objects[i];
                var indexes = obj.indexes;
                if (transposeIndexes)
                {
                    indexes = transpose(indexes, bw, bh);
                }
                int baseAddr = addr + i * (fullSize + stride);
                for (int bi = 0; bi < blockSize; bi++)
                {
                    romdata[baseAddr + bi] = (byte)indexes[bi];
                }
                if (withAttribs)
                {
                    for (int pi = 0; pi < palSize; pi++)
                    {
                        romdata[baseAddr + blockSize + pi] = (byte)obj.palBytes[pi];
                    }
                }
            }
        }

        public static ObjRec[] getBlocksFromTiles16Pal1()
        {
            return readBlocksLinearTiles16Pal1(Globals.romdata, ConfigScript.getMetatileAddress(), ConfigScript.getPalBytesAddr(), ConfigScript.getBlocksCount());
        }

        public static void setBlocksFromTiles16Pal1(ObjRec[] blocksData)
        {
            writeBlocksLinearTiles16Pal1(blocksData, Globals.romdata, ConfigScript.getMetatileAddress(), ConfigScript.getPalBytesAddr(), ConfigScript.getBlocksCount());
        }

        public static ObjRec[] readBlocksLinearTiles16Pal1(byte[] romdata, int addr, int palBytesAddr, int count)
        {
            int BLOCK_W = 4;
            int BLOCK_H = 4;
            var objects = readBlocksLinear(romdata, addr, BLOCK_W, BLOCK_H, count, false);
            for (int i = 0; i < count; i++)
            {
                int palByte = romdata[palBytesAddr + i];
                var palBytes = new[] { (palByte >> 0) & 3, (palByte >> 2) & 3, (palByte >> 4) & 3, (palByte >> 6) & 3 };
                objects[i].palBytes = palBytes;
            }
            return objects;
        }

        public static void writeBlocksLinearTiles16Pal1(ObjRec[] objects, byte[] romdata, int addr, int palBytesAddr, int count)
        {
            writeBlocksLinear(objects, romdata, addr, count, false);
            for (int i = 0; i < count; i++)
            {
                var objPalBytes = objects[i].palBytes;
                int palByte = objPalBytes[0] | objPalBytes[1] << 2 | objPalBytes[2] << 4 | objPalBytes[3] << 6;
                romdata[palBytesAddr + i] = (byte)palByte;
            }
        }

        public static Screen[] loadScreensDiffSize()
        {
            int totalCount = 0;
            int count = 1;
            for (int i = 0; i < count; i++)
            {
                totalCount += ConfigScript.screenCount;
            }
            var screens = new Screen[totalCount];

            int currentScreen = 0;
            for (int i = 0; i < count; i++)
            {
                for (int scrI = 0; scrI < ConfigScript.screenCount; scrI++)
                {
                    var screen = Globals.getScreen(scrI);
                    screens[currentScreen++] = screen;
                }
            }
            return screens;
        }

        public static void saveScreensToOffset(Screen[] screensData, int firstScreenIndex, int currentOffsetIndex, int layerNo)
        {
            var arrayToSave = Globals.romdata;
            for (int i = 0; i < ConfigScript.screenCount; i++)
            {
                var curScrNo = firstScreenIndex + i;
                var curScreen = screensData[curScrNo];
                var dataToWrite = curScreen.layers[layerNo].data;
                int addr = ConfigScript.levelStartAddress + i * ConfigScript.screenSize;
                for (int x = 0; x < ConfigScript.screenSize; x++)
                    arrayToSave[addr + x] = (byte)dataToWrite[x];
            }
        }

        public static void saveScreensDiffSize(Screen[] screensData)
        {
            int offsetsCount = 0;
            int currentScreenIndex = 0;
            for (int currentOffsetIndex = 0; currentOffsetIndex < offsetsCount; currentOffsetIndex++)
            {
                saveScreensToOffset(screensData, currentScreenIndex, currentOffsetIndex, 0);
                currentScreenIndex += ConfigScript.screenCount;
            }
        }

        public static byte[] readBinFile(string filename)
        {
            try
            {
                filename = ConfigScript.ConfigDirectory + filename;
                using (FileStream f = File.OpenRead(filename))
                {
                    byte[] d = new byte[(int)f.Length];
                    f.Read(d, 0, (int)f.Length);
                    return d;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public static byte[] getPalFromRom(int startAddress)
        {
            byte[] romdata = Globals.romdata;
            byte[] palette = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                // weird palette index math is because each palette should include four colors,
                // but the ROM stores them three at a time since it omits the transparency color
                if ((i + 1) % 4 == 1)
                    palette[i] = 0x0F;
                else
                {
                    palette[i] = romdata[startAddress + i - 1 - i / 4];
                }
            }            
            
            return palette;
        }

        public static byte[] getPatternTableFromRom(int firstHalfAddr, int secondHalfAddr)
        {
            byte[] romdata = Globals.romdata;
            byte[] patternTable = new byte[4096]; // 256 tiles, each tile is 16 bytes
            // allows address indices that are relative to the CHR ROM
            int firstHalfAddress = (firstHalfAddr < 0x20010) ? firstHalfAddr += 0x20010 : firstHalfAddr;
            int secondHalfAddress = (secondHalfAddr < 0x20010) ? secondHalfAddr += 0x20010 : secondHalfAddr;
            for (int i = 0; i < 2048; i++) 
            {
                patternTable[i] = romdata[firstHalfAddress + i];
                patternTable[i + 2048] = romdata[secondHalfAddress + i];
            } 
            
            return patternTable;
        }
    }
}
