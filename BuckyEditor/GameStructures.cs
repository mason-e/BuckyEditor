using System;
using System.Drawing;
using System.Linq;

namespace BuckyEditor
{
    public class ObjRec : IEquatable<ObjRec>
    {
        public ObjRec(int w, int h, int type, int[] indexes, int[] palBytes)
        {
            //getSize() == indexes.Length == (if square) palBytes.Lenghth/4
            this.w = w;
            this.h = h;
            this.type = type;
            this.indexes = indexes;
            this.palBytes = palBytes;
        }

        public ObjRec(int c1, int c2, int c3, int c4, int type, int pal)
        {
            this.indexes = new int[4];
            this.palBytes = new int[1];

            this.indexes[0] = c1;
            this.indexes[1] = c2;
            this.indexes[2] = c3;
            this.indexes[3] = c4;
            this.palBytes[0] = pal;
            this.type = type;
        }

        public ObjRec(ObjRec other)
        {
            w = other.w;
            h = other.h;
            type = other.type;
            indexes = new int[other.indexes.Length];
            palBytes = new int[other.palBytes.Length];
            Array.Copy(other.indexes, indexes, indexes.Length);
            Array.Copy(other.palBytes, palBytes, palBytes.Length);
        }

        public int[] indexes;
        public int[] palBytes;
        public int type;
        public int w = 2, h = 2;

        public int getSize()
        {
            return w * h;
        }

        public virtual int getSubpalette(int i)

        {
            return palBytes[i] & 0x3;
        }

        public virtual int getSubpalette()
        {
            return palBytes[0] & 0x3;
        }

        public virtual int getType()
        {
            return type;
        }

        bool IEquatable<ObjRec>.Equals(ObjRec other)
        {
            if ((w != other.w) || (h != other.h))
            {
                return false;
            }
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] != other.indexes[i])
                    return false;
            }
            for (int p = 0; p < palBytes.Length; p++)
            {
                if (palBytes[p] != other.palBytes[p])
                    return false;
            }
            if (type != other.type)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(Object obj)
        {
            ObjRec other = obj as ObjRec;
            if (other == null)
                return false;
            else
                return ((IEquatable<ObjRec>)this).Equals(other);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (var i in indexes)
            {
                hash += i.GetHashCode();
            }
            foreach (var p in palBytes)
            {
                hash += p.GetHashCode();
            }
            hash += type.GetHashCode();
            return hash;
        }
    }

    public class BigBlock : IEquatable<BigBlock>
    {
        public BigBlock(int w, int h)
        {
            width = w;
            height = h;
            indexes = new int[getSize()];
        }

        public int getSize() { return width * height; }

        public virtual int getPalBytes(int index)
        {
            return 0;
        }

        bool IEquatable<BigBlock>.Equals(BigBlock other)
        {
            if (other == null)
                return false;
            return (width == other.width) && (height == other.height) && (indexes.SequenceEqual(other.indexes));
        }

        public override bool Equals(Object obj)
        {
            BigBlock other = obj as BigBlock;
            if (other == null)
                return false;
            else
                return ((IEquatable<BigBlock>)this).Equals(other);
        }

        public override int GetHashCode()
        {
            int hash = width.GetHashCode() + height.GetHashCode();
            foreach (var i in indexes)
            {
                hash += i.GetHashCode();
            }
            return hash;
        }

        public int[] indexes;
        public int width;
        public int height;
    }

    public class BlockLayer
    {
        public int[] data;
        public bool showLayer;

        public BlockLayer(int[] data)
        {
            this.data = data;
            showLayer = true;
        }
    }

    public class Screen
    {
        public Screen(BlockLayer layer, int width, int height)
        {
            this.layer = layer;
            this.width = width;
            this.height = height;
        }

        public int width;
        public int height;
        public BlockLayer layer;
    }
}