﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BuckyEditor
{
    public partial class BlockEdit : Form
    {
        public BlockEdit()
        {
            InitializeComponent();
        }

        private void BlockEdit_Load(object sender, EventArgs e)
        {
            showGridlines = true;
            cbSubpalette.DrawItem += new DrawItemEventHandler(cbSubpalette_DrawItemEvent);
            dirty = false;

            reloadLevel();
            preparePanel();
            resetControls();

            //rebuild video
            reloadLevel();
        }

        protected virtual void resetControls()
        {
            UtilsGui.setCbItemsCount(cbPalette, 1);

            UtilsGui.setCbIndexWithoutUpdateLevel(cbSubpalette, cbSubpalette_SelectedIndexChanged);
        }

        protected void reloadLevel(bool resetDirty = true)
        {
            setPal();
            setVideo();
            setVideoImage();
            setObjects();
            if (resetDirty)
                dirty = false;
        }

        protected void setPal()
        {
            palette = Utils.getPalFromRom(ConfigScript.paletteAddress);
            //set image for pallete
            var b = new Bitmap(16 * 16, 16);
            using (Graphics g = Graphics.FromImage(b))
            {
                for (int i = 0; i < Globals.palLen; i++)
                    g.FillRectangle(new SolidBrush(Globals.mesenColors[palette[i]]), i * 16, 0, 16, 16);
            }
            paletteMap.Image = b;

            //set images for subpalletes
            subpalSprites.Images.Clear();
            for (int i = 0; i < 4; i++)
            {
                var sb = new Bitmap(16 * 4, 16);
                using (Graphics g = Graphics.FromImage(sb))
                {
                    g.FillRectangle(new SolidBrush(Globals.mesenColors[palette[i * 4]]), 0, 0, 16, 16);
                    g.FillRectangle(new SolidBrush(Globals.mesenColors[palette[i * 4 + 1]]), 16, 0, 16, 16);
                    g.FillRectangle(new SolidBrush(Globals.mesenColors[palette[i * 4 + 2]]), 32, 0, 16, 16);
                    g.FillRectangle(new SolidBrush(Globals.mesenColors[palette[i * 4 + 3]]), 48, 0, 16, 16);
                }
                subpalSprites.Images.Add(sb);
            }
        }

        private void setObjects()
        {
            objects = ConfigScript.getBlocks();
            refillPanel();
        }

        protected void setVideo()
        {
            var chunk = Utils.getPatternTableFromRom(ConfigScript.patternTableAddresses);
            for (int i = 0; i < 4; i++)
            {
                videoSprites[i] = Enumerable.Range(0, 256).Select(t => (Bitmap)UtilsGDI.ResizeBitmap(NesDrawing.makeImage(t, chunk, palette, i), 16, 16)).ToArray();
            }
        }

        protected void setVideoImage()
        {
            var b = new Bitmap(TileSize * 16, TileSize * 16);
            using (Graphics g = Graphics.FromImage(b))
            {
                for (int i = 0; i < Globals.chunksCount; i++)
                {
                    int x = i % 16;
                    int y = i / 16;
                    g.DrawImage(videoSprites[curSubpalIndex][i], new Rectangle(x * TileSize, y * TileSize, TileSize, TileSize));
                }
            }
            mapScreen.Image = b;
        }

        //editor
        protected int curSubpalIndex;
        protected int curActiveBlock;

        protected int curPageIndex;
        private const int BlocksPerPage = 256;

        protected byte[] palette = new byte[Globals.palLen];
        protected ObjRec[] objects = new ObjRec[256];
        protected Bitmap[][] videoSprites = new Bitmap[4][];
        protected bool dirty;
        protected bool readOnly;
        protected bool showGridlines;

        private const int TileSize = 16;

        protected string[] subPalItems = { "1", "2", "3", "4" };

        protected FormMain formMain;

        protected void cbSubpalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubpalette.SelectedIndex == -1)
                return;
            curSubpalIndex = cbSubpalette.SelectedIndex;
            setVideoImage();
        }

        protected void cbSubpalette_DrawItemEvent(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                return;
            }
            e.DrawBackground();
            e.Graphics.DrawImage(subpalSprites.Images[e.Index], e.Bounds.Width - 63, e.Bounds.Y, 64, 16);
            string text = cbSubpalette.Items[e.Index].ToString();
            e.Graphics.DrawString(text, cbSubpalette.Font,
                Brushes.Black,
                new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            e.DrawFocusRectangle();
        }

        protected void pb_MouseClick(object sender, MouseEventArgs e)
        {
            bool left = e.Button == MouseButtons.Left;
            int x = e.X / TileSize;
            int y = e.Y / TileSize;
            PictureBox p = (PictureBox)sender;
            int objIndex = curPageIndex * BlocksPerPage + (int)p.Tag;
            var obj = objects[objIndex];
            if (x >= 0 && x < obj.w && y >= 0 && y < obj.h)
            {
                if (left)
                {
                    obj.indexes[y * obj.w + x] = curActiveBlock;
                }
                else
                {
                    //action 1
                    int palIndex = (y >> 1) * (obj.w >> 1) + (x >> 1);
                    int curPal = obj.palBytes[palIndex];
                    if (++curPal > 3) { curPal = 0; }
                    obj.palBytes[palIndex] = curPal;
                    //action 2
                    curActiveBlock = obj.indexes[y * obj.w + x];
                }
            }
            p.Image = makeObjImage(objIndex);
            pbActive.Image = videoSprites[curSubpalIndex][curActiveBlock];
            lbActive.Text = String.Format("({0:X})", curActiveBlock);
            dirty = true;
        }

        protected void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            PictureBox pb = (PictureBox)cb.Tag;
            int index = curPageIndex * BlocksPerPage + (int)pb.Tag;
            objects[index].palBytes[0] = cb.SelectedIndex;
            pb.Image = makeObjImage(index);
            dirty = true;
        }

        protected void nudType_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudType = (NumericUpDown)sender;
            int index = curPageIndex * BlocksPerPage + (int)nudType.Tag;
            objects[index].type = (int)nudType.Value;
            dirty = true;
        }

        public Image makeObjImage(int index)
        {
            return NesDrawing.makeObject(index, objects, videoSprites, MapViewType.Tiles);
        }

        protected void mapScreen_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / TileSize;
            int y = e.Y / TileSize;
            curActiveBlock = y * TileSize + x;
            pbActive.Image = videoSprites[curSubpalIndex][curActiveBlock];
            lbActive.Text = String.Format("({0:X})", curActiveBlock);
            dirty = true;
        }

        protected virtual bool saveToFile()
        {
            ConfigScript.setBlocks(objects);
            dirty = !Globals.flushToFile();
            return !dirty;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            saveToFile();
        }

        protected void BlockEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!readOnly && dirty)
            {
                DialogResult dr = MessageBox.Show("Tiles was changed. Do you want to save current tileset?", "Save", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    saveToFile();
            }
        }

        private void preparePanel()
        {
            //GUI
            mapObjects.Controls.Clear();
            mapObjects.SuspendLayout();
            int endIndex = Math.Min(BlocksPerPage, ConfigScript.getBlocksCount());
            var objectTypes = ConfigScript.getBlockTypeNames();
            for (int i = 0; i < endIndex; i++)
            {
                var obj = objects[i];
                int curPanelX = 0;

                Panel fp = new Panel();
                fp.Size = new Size(mapObjects.Width - 25, TileSize * obj.h);
                //
                Label lb = new Label();
                lb.Location = new Point(curPanelX, 0);
                lb.Size = new Size(32, 32);
                lb.Tag = i;
                lb.Text = String.Format("{0:X}", i);
                fp.Controls.Add(lb);
                curPanelX += lb.Size.Width;
                //
                PictureBox pb = new PictureBox();
                pb.Location = new Point(curPanelX, 0);
                pb.Size = new Size(TileSize * obj.w, TileSize * obj.h);
                pb.Tag = i;
                pb.MouseClick += pb_MouseClick;
                fp.Controls.Add(pb);
                curPanelX += pb.Size.Width + 6;
                //
                ComboBox cbColor = new ComboBox();
                cbColor.Size = cbSubpalette.Size;
                cbColor.Location = new Point(curPanelX, 0);
                cbColor.Tag = pb;
                cbColor.DrawMode = DrawMode.OwnerDrawVariable;
                cbColor.DrawItem += cbSubpalette_DrawItemEvent;
                cbColor.Items.AddRange(subPalItems);
                cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
                cbColor.SelectedIndexChanged += cbColor_SelectedIndexChanged;
                fp.Controls.Add(cbColor);
                curPanelX += cbColor.Size.Width;
                //
                NumericUpDown nudType = new NumericUpDown();
                nudType.Size = cbSubpalette.Size;
                nudType.Location = new Point(curPanelX, 0);
                nudType.Tag = i;
                nudType.Minimum = 0;
                nudType.Maximum = objectTypes.Length - 1;
                nudType.Hexadecimal = true;
                nudType.ValueChanged += nudType_ValueChanged;
                fp.Controls.Add(nudType);

                mapObjects.Controls.Add(fp);
            }
            mapObjects.ResumeLayout();

            refillPanel();
        }

        protected virtual void refillPanel()
        {
            //GUI
            if (mapObjects.Controls.Count == 0)
            {
                return;
            }

            mapObjects.SuspendLayout();
            int startIndex = curPageIndex * BlocksPerPage;
            int endIndex = Math.Min(startIndex + BlocksPerPage, ConfigScript.getBlocksCount());
            int pi = 0;
            for (int i = startIndex; i < endIndex; i++, pi++)
            {
                Panel p = (Panel)mapObjects.Controls[pi];
                p.Visible = true;
                Label lb = (Label)p.Controls[0];
                lb.Text = String.Format("{0:X}", i);
                PictureBox pb = (PictureBox)p.Controls[1];
                pb.Image = makeObjImage(i);
                ComboBox cbColor = (ComboBox)p.Controls[2];
                cbColor.SelectedIndex = objects[i].getSubpallete();
                NumericUpDown nudType = (NumericUpDown)p.Controls[3];
                nudType.Value = objects[i].getType();
            }
            for (; pi < mapObjects.Controls.Count; pi++)
            {
                Panel p = (Panel)mapObjects.Controls[pi];
                p.Visible = false;
            }
            mapObjects.ResumeLayout();
        }

        private void VisibleOnlyChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadLevel(false);
        }

        public void setFormMain(FormMain f)
        {
            formMain = f;
        }

    }
}
