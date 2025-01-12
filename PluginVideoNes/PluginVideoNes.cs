using System;
using System.Drawing;
using System.Linq;
//using System.Windows.Forms;

using CadEditor;

namespace PluginVideoNes
{
    public class Video : IVideoPluginNes
    {
        public string getName()
        {
            return "Nes Video Plugin";
        }
        static Video()
        {
            nesColors[0] = Color.FromArgb(102, 102, 102);
            nesColors[1] = Color.FromArgb(0, 42, 136);
            nesColors[2] = Color.FromArgb(20, 18, 167);
            nesColors[3] = Color.FromArgb(59, 0, 164);
            nesColors[4] = Color.FromArgb(92, 0, 126);
            nesColors[5] = Color.FromArgb(110, 0, 64);
            nesColors[6] = Color.FromArgb(108, 6, 0);
            nesColors[7] = Color.FromArgb(86, 29, 0);
            nesColors[8] = Color.FromArgb(51, 53, 0);
            nesColors[9] = Color.FromArgb(11, 72, 0);
            nesColors[0xA] = Color.FromArgb(0, 82, 0);
            nesColors[0xB] = Color.FromArgb(0, 79, 8);
            nesColors[0xC] = Color.FromArgb(0, 64, 77);
            nesColors[0xD] = Color.FromArgb(0, 0, 0);
            nesColors[0xE] = Color.FromArgb(0, 0, 0);
            nesColors[0xF] = Color.FromArgb(0, 0, 0);

            nesColors[0x10] = Color.FromArgb(173, 173, 173);
            nesColors[0x11] = Color.FromArgb(21, 95, 217);
            nesColors[0x12] = Color.FromArgb(64, 64, 255);
            nesColors[0x13] = Color.FromArgb(117, 39, 254);
            nesColors[0x14] = Color.FromArgb(160, 26, 204);
            nesColors[0x15] = Color.FromArgb(183, 30, 123);
            nesColors[0x16] = Color.FromArgb(181, 49, 32);
            nesColors[0x17] = Color.FromArgb(153, 78, 0);
            nesColors[0x18] = Color.FromArgb(107, 109, 0);
            nesColors[0x19] = Color.FromArgb(56, 135, 0);
            nesColors[0x1A] = Color.FromArgb(12, 147, 0);
            nesColors[0x1B] = Color.FromArgb(0, 143, 50);
            nesColors[0x1C] = Color.FromArgb(0, 124, 141);
            nesColors[0x1D] = Color.FromArgb(0, 0, 0);
            nesColors[0x1E] = Color.FromArgb(0, 0, 0);
            nesColors[0x1F] = Color.FromArgb(0, 0, 0);

            nesColors[0x20] = Color.FromArgb(255, 254, 255);
            nesColors[0x21] = Color.FromArgb(100, 176, 255);
            nesColors[0x22] = Color.FromArgb(146, 144, 255);
            nesColors[0x23] = Color.FromArgb(198, 118, 255);
            nesColors[0x24] = Color.FromArgb(243, 106, 255);
            nesColors[0x25] = Color.FromArgb(254, 110, 204);
            nesColors[0x26] = Color.FromArgb(254, 129, 112);
            nesColors[0x27] = Color.FromArgb(234, 158, 34);
            nesColors[0x28] = Color.FromArgb(188, 190, 0);
            nesColors[0x29] = Color.FromArgb(136, 216, 0);
            nesColors[0x2A] = Color.FromArgb(92, 228, 48);
            nesColors[0x2B] = Color.FromArgb(69, 224, 130);
            nesColors[0x2C] = Color.FromArgb(75, 205, 222);
            nesColors[0x2D] = Color.FromArgb(79, 79, 79);
            nesColors[0x2E] = Color.FromArgb(0, 0, 0);
            nesColors[0x2F] = Color.FromArgb(0, 0, 0);

            nesColors[0x30] = Color.FromArgb(255, 254, 255);
            nesColors[0x31] = Color.FromArgb(192, 223, 255);
            nesColors[0x32] = Color.FromArgb(211, 210, 255);
            nesColors[0x33] = Color.FromArgb(232, 200, 255);
            nesColors[0x34] = Color.FromArgb(215, 194, 255);
            nesColors[0x35] = Color.FromArgb(254, 196, 234);
            nesColors[0x36] = Color.FromArgb(254, 204, 197);
            nesColors[0x37] = Color.FromArgb(247, 216, 165);
            nesColors[0x38] = Color.FromArgb(228, 229, 148);
            nesColors[0x39] = Color.FromArgb(207, 239, 150);
            nesColors[0x3A] = Color.FromArgb(189, 244, 171);
            nesColors[0x3B] = Color.FromArgb(179, 243, 204);
            nesColors[0x3C] = Color.FromArgb(181, 235, 242);
            nesColors[0x3D] = Color.FromArgb(184, 184, 184);
            nesColors[0x3E] = Color.FromArgb(0, 0, 0);
            nesColors[0x3F] = Color.FromArgb(0, 0, 0);

            cadObjectTypeColors[0x0] = Color.FromArgb(196, 0, 255, 0);
            cadObjectTypeColors[0x1] = Color.FromArgb(196, 0, 255, 0);
            cadObjectTypeColors[0x2] = Color.FromArgb(196, 0, 196, 0);
            cadObjectTypeColors[0x3] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0x4] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0x5] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0x6] = Color.FromArgb(196, 0, 255, 0);
            cadObjectTypeColors[0x7] = Color.FromArgb(196, 255, 255, 0);
            cadObjectTypeColors[0x8] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0x9] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0xA] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0xB] = Color.FromArgb(196, 0, 0, 0);
            cadObjectTypeColors[0xC] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0xD] = Color.FromArgb(196, 255, 0, 0);
            cadObjectTypeColors[0xE] = Color.FromArgb(196, 0, 255, 255);
            cadObjectTypeColors[0xF] = Color.FromArgb(196, 0, 255, 255);
        }

        public void updateColorsFromConfig()
        {
            if (ConfigScript.nesColors != null)
                nesColors = ConfigScript.nesColors;
        }

        public Bitmap makeImage(int index, byte[] videoChunk, byte[] pallete, int subPalIndex, bool withAlpha = false)
        {
            Bitmap res = new Bitmap(8, 8);
            using (Graphics g = Graphics.FromImage(res))
            {
                int i = index;
                int beginIndex = 16 * i;
                for (int line = 0; line < 8; line++)
                {
                    for (int pixel = 0; pixel < 8; pixel++)
                    {
                        bool bitLo = Utils.getBit(videoChunk[beginIndex + line], 8 - pixel);
                        bool bitHi = Utils.getBit(videoChunk[beginIndex + line + 8], 8 - pixel);
                        int palIndex = mixBits(bitHi, bitLo);
                        int fullPalIndex = subPalIndex * 4 + palIndex;
                        bool isBackColor = fullPalIndex % 4 == 0;
                        int colorNo = pallete[isBackColor ? 0 : fullPalIndex];
                        Color c = (withAlpha && isBackColor) ? Color.FromArgb(0) : nesColors[colorNo];
                        res.SetPixel(pixel, line, c);
                    }
                }
            }
            return res;
        }

        private Bitmap[] makeObjects(ObjRec[] objects, Bitmap[][] objStrips, MapViewType drawType, int constantSubpal = -1)
        {
            var ans = new Bitmap[objects.Length];
            for (int index = 0; index < objects.Length; index++)
            {
                ans[index] = makeObject(index, objects, objStrips, drawType, constantSubpal);
            }
            return ans;
        }

        public Bitmap makeObject(int index, ObjRec[] objects, Bitmap[][] objStrips, MapViewType drawType, int constantSubpal = -1)
        {
            var obj = objects[index];
            int scaleInt16 = 16;
            var images = new Image[obj.getSize()];
            for (int i = 0; i < obj.getSize(); i++)
            {
                int x = i % obj.w;
                int y = i / obj.w;
                int pali = (y >> 1) * (obj.w >> 1) + (x >> 1);
                var objStrip = constantSubpal == -1 ? objStrips[obj.getSubpallete(pali)] : objStrips[constantSubpal];
                images[i] = objStrip[obj.indexes[i]];
            }

            var mblock = UtilsGDI.GlueImages(images, obj.w, obj.h);
            using (Graphics g2 = Graphics.FromImage(mblock))
            {
                if (drawType == MapViewType.ObjType)
                {
                    int objType = obj.getType();
                    var col = (objType < cadObjectTypeColors.Length) ? cadObjectTypeColors[objType] : cadObjectTypeColors[0];
                    g2.FillRectangle(new SolidBrush(col), new Rectangle(0, 0, scaleInt16, scaleInt16));
                    g2.DrawString(String.Format("{0:X}", obj.getType()), new Font("Arial", 6), Brushes.White, new Point(0, 0));
                }
                else if (drawType == MapViewType.ObjNumbers)
                {
                    g2.FillRectangle(new SolidBrush(Color.FromArgb(192, 255, 255, 255)), new Rectangle(0, 0, scaleInt16, scaleInt16));
                    g2.DrawString(String.Format("{0:X}", index), new Font("Arial", 6), Brushes.Red, new Point(0, 0));
                }
            }
            return mblock;
        }

        private Bitmap[] makeObjects(int videoPageId, int tilesId, int palId, MapViewType drawType, int constantSubpal = -1)
        {
            byte[] videoChunk = Utils.getPatternTableFromRom(ConfigScript.patternTableAddress);
            ObjRec[] objects = ConfigScript.getBlocks(tilesId);

            byte[] palette = Utils.getPalFromRom(ConfigScript.paletteAddress);
            var range256 = Enumerable.Range(0, 256);
            var objStrip1 = range256.Select(i => makeImage(i, videoChunk, palette, 0)).ToArray();
            var objStrip2 = range256.Select(i => makeImage(i, videoChunk, palette, 1)).ToArray();
            var objStrip3 = range256.Select(i => makeImage(i, videoChunk, palette, 2)).ToArray();
            var objStrip4 = range256.Select(i => makeImage(i, videoChunk, palette, 3)).ToArray();
            var objStrips = new[] { objStrip1, objStrip2, objStrip3, objStrip4 };

            var bitmaps = makeObjects(objects, objStrips, drawType, constantSubpal);
            return bitmaps;
        }

        public Image[] makeBigBlocks(int videoNo, int bigBlockNo, int blockNo, int palleteNo, MapViewType smallObjectsViewType = MapViewType.Tiles,
          MapViewType curViewType = MapViewType.Tiles)
        {
            BigBlock[] bigBlockIndexes = ConfigScript.getBigBlocksRecursive(bigBlockNo);
            return makeBigBlocks(videoNo, bigBlockNo, blockNo, bigBlockIndexes, palleteNo, smallObjectsViewType, curViewType);
        }

        public Image[] makeBigBlocks(int videoNo, int bigBlockNo, int blockNo, BigBlock[] bigBlockIndexes, int palleteNo, MapViewType smallObjectsViewType = MapViewType.Tiles,
            MapViewType curViewType = MapViewType.Tiles)
        {
            int blockCount = ConfigScript.getBigBlocksCount();
            var bigBlocks = new Image[blockCount];

            Image[] smallBlocksPack;
            smallBlocksPack = makeObjects(videoNo, blockNo, palleteNo, smallObjectsViewType);

            //tt version hardcode
            Image[][] smallBlocksAll = null;

            bool smallBlockHasSubpals = bigBlockIndexes == null ? true : bigBlockIndexes[0].smallBlocksWithPal();
            if (!smallBlockHasSubpals)
            {
                smallBlocksAll = new Image[4][];
                for (int i = 0; i < 4; i++)
                {
                    smallBlocksAll[i] = makeObjects(videoNo, bigBlockNo, palleteNo, smallObjectsViewType, i);
                }
            }
            else
            {
                smallBlocksAll = new Image[4][] { smallBlocksPack, smallBlocksPack, smallBlocksPack, smallBlocksPack };
            }

            for (int btileId = 0; btileId < blockCount; btileId++)
            {
                Image b;
                var sb = smallBlocksPack[btileId];
                //scale for small blocks
                b = UtilsGDI.ResizeBitmap(sb, (int)(sb.Width * 2), (int)(sb.Height * 2));
                if (curViewType == MapViewType.ObjNumbers)
                    b = VideoHelper.addObjNumber(b, btileId);
                bigBlocks[btileId] = b;
            }
            return bigBlocks;
        }

        public Color[] defaultNesColors
        {
            get { return nesColors; }
            set { nesColors = value; }
        }

        private static int mixBits(bool hi, bool lo)
        {
            return (hi ? 1 : 0) << 1 | (lo ? 1 : 0);
        }

        public static int nesColorsCount = 64;
        public static int chunkCount = 256;
        public static Color[] nesColors = new Color[nesColorsCount];

        const int CadObjtypesCount = 16;
        public static Color[] cadObjectTypeColors = new Color[CadObjtypesCount];
    }
}
