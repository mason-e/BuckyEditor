using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CadEditor
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

        //strip ints to bytes
        public static byte[] linearizeBigBlocks(BigBlock[] bigBlocks)
        {
            if ((bigBlocks == null) || (bigBlocks.Length == 0))
            {
                return new byte[0];
            }
            byte[] result = new byte[bigBlocks.Length * bigBlocks[0].getSize()];
            for (int i = 0; i < bigBlocks.Length; i++)
            {
                int size = bigBlocks[i].getSize();
                var byteIndexes = bigBlocks[i].indexes.Select(old => (byte)old).ToArray();
                Array.Copy(byteIndexes, 0, result, i * size, size);
            }
            return result;
        }

        public static T[] unlinearizeBigBlocks<T>(byte[] data, int w, int h)
            where T : BigBlock
        {
            if ((data == null) || (data.Length == 0))
            {
                return new T[0];
            }
            int size = w * h;
            T[] result = new T[data.Length / size];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Activator.CreateInstance(typeof(T), w, h) as T;
                Array.Copy(data, i * size, result[i].indexes, 0, size);
            }
            return result;
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

        public static ObjRec[] getBlocksFromTiles16Pal1(int blockIndex)
        {
            return readBlocksLinearTiles16Pal1(Globals.romdata, ConfigScript.getTilesAddr(blockIndex), ConfigScript.getPalBytesAddr(), ConfigScript.getBlocksCount());
        }

        public static void setBlocksFromTiles16Pal1(int blockIndex, ObjRec[] blocksData)
        {
            writeBlocksLinearTiles16Pal1(blocksData, Globals.romdata, ConfigScript.getTilesAddr(blockIndex), ConfigScript.getPalBytesAddr(), ConfigScript.getBlocksCount());
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

        //
        public static int readWord(byte[] data, int addr)
        {
            return (short)(data[addr] << 8 | data[addr + 1]);
        }

        public static int readWordLE(byte[] data, int addr)
        {
            return (short)(data[addr + 1] << 8 | data[addr]);
        }

        public static void writeWord(byte[] data, int addr, int word)
        {
            data[addr] = (byte)(word >> 8);
            data[addr + 1] = (byte)(word & 0xFF);
        }

        public static void writeWordLE(byte[] data, int addr, int word)
        {
            data[addr + 1] = (byte)(word >> 8);
            data[addr] = (byte)(word & 0xFF);
        }

        public static Screen[] loadScreensDiffSize()
        {
            var offsets = ConfigScript.screensOffset;
            int totalCount = 0;
            int count = offsets.Length;
            for (int i = 0; i < count; i++)
            {
                totalCount += offsets[i].recCount;
            }
            var screens = new Screen[totalCount];

            int currentScreen = 0;
            for (int i = 0; i < count; i++)
            {
                for (int scrI = 0; scrI < offsets[i].recCount; scrI++)
                {
                    var screen = Globals.getScreen(offsets[i], scrI);
                    screens[currentScreen++] = screen;
                }
            }
            return screens;
        }

        //save screensData from firstScreenIndex to ConfigScript.screensOffset[currentOffset]
        public static void saveScreensToOffset(OffsetRec screensRec, Screen[] screensData, int firstScreenIndex, int currentOffsetIndex, int layerNo)
        {
            var arrayToSave = Globals.romdata;
            for (int i = 0; i < screensRec.recCount; i++)
            {
                var curScrNo = firstScreenIndex + i;
                var curScreen = screensData[curScrNo];
                var dataToWrite = curScreen.layers[layerNo].data;
                int addr = screensRec.beginAddr + i * screensRec.recSize;
                for (int x = 0; x < screensRec.recSize; x++)
                    arrayToSave[addr + x] = (byte)dataToWrite[x];
            }
        }

        public static void saveScreensDiffSize(Screen[] screensData)
        {
            int offsetsCount = ConfigScript.screensOffset.Length;
            int currentScreenIndex = 0;
            for (int currentOffsetIndex = 0; currentOffsetIndex < offsetsCount; currentOffsetIndex++)
            {
                saveScreensToOffset(ConfigScript.screensOffset[currentOffsetIndex], screensData, currentScreenIndex, currentOffsetIndex, 0);
                currentScreenIndex += ConfigScript.screensOffset[currentOffsetIndex].recCount;
            }
            //todo: save all layers
        }

        public static byte[] readVideoBankFromFile(string filename, int videoPageId)
        {
            try
            {
                filename = ConfigScript.ConfigDirectory + filename;

                using (FileStream f = File.OpenRead(filename))
                {

                    byte[] videodata = new byte[(int)f.Length];
                    f.Read(videodata, 0, (int)f.Length);
                    byte[] ans = new byte[0x1000];
                    int offset = videoPageId * 0x1000;
                    for (int i = 0; i < ans.Length; i++)
                        ans[i] = videodata[offset + i];
                    return ans;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
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

        public static GetPalFunc readPalFromBin(string[] fname)
        {
            return (int x) => { return readBinFile(fname[x]); };
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

        public static byte[] getPatternTableFromRom(int startAddress)
        {
            byte[] romdata = Globals.romdata;
            byte[] patternTable = new byte[4096]; // 256 tiles, each tile is 16 bytes
            for (int i = 0; i < 4096; i++)
                patternTable[i] = romdata[startAddress + i];
            
            return patternTable;
        }
    }
}
