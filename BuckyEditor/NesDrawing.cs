using System;
using System.Drawing;
using System.Linq;

namespace BuckyEditor
{
    public static class NesDrawing
    {
        public static Bitmap makeImage(int index, byte[] videoChunk, byte[] palette, int subPalIndex, bool withAlpha = false)
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
                        int colorNo = palette[isBackColor ? 0 : fullPalIndex];
                        Color c = (withAlpha && isBackColor) ? Color.FromArgb(0) : Globals.mesenColors[colorNo];
                        res.SetPixel(pixel, line, c);
                    }
                }
            }
            return res;
        }

        private static Bitmap[] makeObjects(ObjRec[] objects, Bitmap[][] objStrips)
        {
            var ans = new Bitmap[objects.Length];
            for (int index = 0; index < objects.Length; index++)
            {
                ans[index] = makeObject(index, objects, objStrips);
            }
            return ans;
        }

        public static Bitmap makeObject(int index, ObjRec[] objects, Bitmap[][] objStrips)
        {
            var obj = objects[index];
            var images = new Image[obj.getSize()];
            for (int i = 0; i < obj.getSize(); i++)
            {
                int x = i % obj.w;
                int y = i / obj.w;
                int pali = (y >> 1) * (obj.w >> 1) + (x >> 1);
                var objStrip =  objStrips[obj.getSubpalette(pali)];
                images[i] = objStrip[obj.indexes[i]];
            }

            var mblock = UtilsGDI.GlueImages(images, obj.w, obj.h);
            using (Graphics g2 = Graphics.FromImage(mblock))
            return mblock;
        }

        private static Bitmap[] makeObjects(int palIndex, int patternTableIndex)
        {
            // All of the pattern tables in the game only have up to one half that
            // can change for the current screen. All but one have the second half that changes,
            // so default to assuming the second half is the bigger one. 
            int firstHalf = ConfigScript.patternTableFirstHalfAddr[0];
            int secondHalf = ConfigScript.patternTableSecondHalfAddr[patternTableIndex];
            if (ConfigScript.patternTableFirstHalfAddr.Length > ConfigScript.patternTableSecondHalfAddr.Length)
            {
                firstHalf = ConfigScript.patternTableFirstHalfAddr[patternTableIndex];
                secondHalf = ConfigScript.patternTableSecondHalfAddr[0];
            }
            byte[] videoChunk = Utils.getPatternTableFromRom(firstHalf, secondHalf);
            ObjRec[] objects = ConfigScript.getBlocks();

            byte[] palette = Utils.getPalFromRom(ConfigScript.paletteAddresses[palIndex]);
            var range256 = Enumerable.Range(0, 256);
            var objStrip1 = range256.Select(i => makeImage(i, videoChunk, palette, 0)).ToArray();
            var objStrip2 = range256.Select(i => makeImage(i, videoChunk, palette, 1)).ToArray();
            var objStrip3 = range256.Select(i => makeImage(i, videoChunk, palette, 2)).ToArray();
            var objStrip4 = range256.Select(i => makeImage(i, videoChunk, palette, 3)).ToArray();
            var objStrips = new[] { objStrip1, objStrip2, objStrip3, objStrip4 };

            var bitmaps = makeObjects(objects, objStrips);
            return bitmaps;
        }

        public static Image[] makeBigBlocks(bool drawNumbers, int palIndex, int patternTableIndex)
        {
            int blockCount = ConfigScript.getBlocksCount();
            var bigBlocks = new Image[blockCount];

            Image[] smallBlocksPack;
            smallBlocksPack = makeObjects(palIndex, patternTableIndex);

            //tt version hardcode
            Image[][] smallBlocksAll = new Image[4][] { smallBlocksPack, smallBlocksPack, smallBlocksPack, smallBlocksPack };

            for (int btileId = 0; btileId < blockCount; btileId++)
            {
                Image b;
                var sb = smallBlocksPack[btileId];
                //scale for small blocks
                b = UtilsGDI.ResizeBitmap(sb, (int)(sb.Width * 2), (int)(sb.Height * 2));
                if (drawNumbers)
                    b = VideoHelper.addObjNumber(b, btileId);
                bigBlocks[btileId] = b;
            }
            return bigBlocks;
        }

        private static int mixBits(bool hi, bool lo)
        {
            return (hi ? 1 : 0) << 1 | (lo ? 1 : 0);
        }
    }
}