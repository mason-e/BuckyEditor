using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CadEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            if (OpenFile.fileName == "" || OpenFile.configName == "")
            {
                if (!openFile())
                {
                    Close();
                    return;
                }
            }
            else
            {
                if (!Globals.loadData(OpenFile.fileName, OpenFile.configName))
                {
                    Close();
                    return;
                }
                fileLoaded = true;

                resetControls();
            }

            subeditorsDict = new Dictionary<ToolStripButton, Func<Form>> {
                 { bttBlocks,       makeBlocksEditor },
            };
        }

        private Form makeBlocksEditor()
        {
            var f = new BlockEdit();
            f.setFormMain(this);
            return f;
        }

        private void resetScreens()
        {
            screens = ConfigScript.loadScreens();
            int count = screens.Length;

            int oldScreenNo = cbScreenNo.SelectedIndex;
            cbScreenNo.Items.Clear();
            for (int i = 0; i < count; i++)
                cbScreenNo.Items.Add(String.Format("{0:X}", i + 1));

            if (oldScreenNo == -1)
                cbScreenNo.SelectedIndex = 0;
            else if (oldScreenNo < cbScreenNo.Items.Count)
                cbScreenNo.SelectedIndex = oldScreenNo;
        }

        private void resetControls()
        {
            clearSubeditorButtons();
            resetScreens();

            UtilsGui.setCbIndexWithoutUpdateLevel(cbViewType, cbLevel_SelectedIndexChanged);


            dirty = false; updateSaveVisibility();
            showNeiScreens = true;
            showGridlines = true;
            curActiveLayer = 0;

            changeLevelIndex(true);

            bttBlocks.Enabled = true;

            tsLayer1.Enabled = true;

            curActiveLayer = 0;

            resetMapScreenSize();
        }

        void resetMapScreenSize()
        {
            if (bigBlocks.Length > 0)
            {
                var screen = getActiveScreen();
                mapScreen.Size = new Size((screen.width + 2) * bigBlocks[0].Width, screen.height * bigBlocks[0].Height);
            }
        }

        public void reloadLevel(bool reloadScreens = true, bool rebuildBlocks = false)
        {
            setBlocks(rebuildBlocks);
            if (reloadScreens)
                resetScreens();
            mapScreen.Invalidate();
        }

        private void setBlocks(bool needRebuildBlocks)
        {
            MapViewType smallObjectsType =
                curActiveViewType == MapViewType.SmallObjNumbers ? MapViewType.ObjNumbers :
                    curActiveViewType == MapViewType.ObjType ? MapViewType.ObjType : MapViewType.Tiles;

            if (needRebuildBlocks)
            {
                bigBlocks = NesDrawing.makeBigBlocks( curActiveBigBlockNo,  smallObjectsType, curActiveViewType);
            }

            curActiveBlock = 0;
            updateBlocksImages();
        }

        private void updateBlocksImages()
        {
            if (bigBlocks.Length > 0)
            {
                UtilsGui.resizeBlocksScreen(bigBlocks, blocksScreen, bigBlocks[0].Width, bigBlocks[0].Height);
                blocksScreen.Invalidate();
            }
        }

        private void renderNeighborLine(Graphics g, int scrNo, int line, int x)
        {
            Screen prevScreen = screens[scrNo];
            int width = prevScreen.width;
            int height = prevScreen.height;
            int tileSizeX = bigBlocks[0].Width;
            int tileSizeY = bigBlocks[0].Height;
            int size = width * height;
            int[] indexesPrev = prevScreen.layers[0].data;
            for (int i = 0; i < size; i++)
            {
                if (i % width == line)
                {
                    int bigBlockNo = Utils.getBigTileNoFromScreen(indexesPrev, i);
                    if ((bigBlockNo >= 0) && (bigBlockNo < bigBlocks.Length))
                        g.DrawImage(bigBlocks[bigBlockNo], new Rectangle(x, i / width * tileSizeY, tileSizeX, tileSizeY));
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!fileLoaded)
                return;
            var g = e.Graphics;

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            var screen = getActiveScreen();

            int width = screen.width;
            int height = screen.height;
            int tileSizeX = bigBlocks[0].Width;
            int tileSizeY = bigBlocks[0].Height;
            var visibleRect = UtilsGui.getVisibleRectangle(pnView, mapScreen);
            MapEditor.render(e.Graphics, screens, screenNo, new MapEditor.RenderParams
            {
                bigBlocks = bigBlocks,
                visibleRect = visibleRect,
                showBlocksGridlines = showGridlines,
                showBorder = true,
                width = width,
                height = height,
                additionalRenderEnabled = additionalRenderEnabled,
                leftMargin = tileSizeX,
                topMargin = 0
            });

            if (showNeiScreens && (screenNo > 0) && screen.layers[0].showLayer)
            {
                renderNeighborLine(g, screenNo - 1, (width - 1), 0);
            }
            if (showNeiScreens && (screenNo < ConfigScript.screensOffset[0].recCount - 1) && screen.layers[0].showLayer)
            {
                renderNeighborLine(g, screenNo + 1, 0, (width + 1) * tileSizeX);
            }

            if (curActiveBlock != -1 && (curDx != Outside || curDy != Outside))
            {
                var tx = (curDx + 1) * tileSizeX;
                var ty = curDy * tileSizeY;
                var tileRect = new Rectangle(tx, ty, tileSizeX, tileSizeY);
                g.DrawImage(bigBlocks[curActiveBlock], tileRect);
            }

        }

        //editor globals
        private int curActiveBlock;

        //generic
        private bool dirty;
        private bool showNeiScreens;

        public static bool fileLoaded;

        const int Outside = -10;
        private int curDx = Outside;
        private int curDy = Outside;
        private bool curClicked;

        private int curActiveLayer;

        //select rect if alt pressed
        private int selectionBeginX, selectionBeginY, selectionEndX, selectionEndY;
        private int selectionBeginMouseX, selectionBeginMouseY, selectionMouseX, selectionMouseY;
        private bool selectionRect;

        private Dictionary<ToolStripButton, Func<Form>> subeditorsDict;

        private void mapScreen_MouseClick(object sender, MouseEventArgs ea)
        {
            var ee = ea.Location;
            if (ee.X < 0) { ee.X += 32768 * 2; }
            if (ee.Y < 0) { ee.Y += 32768 * 2; }

            var screen = getActiveScreen();

            int width = screen.width;

            int dx = ee.X / bigBlocks[0].Width - 1;
            int dy = ee.Y / bigBlocks[0].Height;

            if (ea.Button == MouseButtons.Right)
            {
                if (dx == width || dx == -1)
                    return;
                int index = dy * width + dx;
                var layer = getActiveLayer(screens[screenNo]);
                curActiveBlock = Utils.getBigTileNoFromScreen(layer.data, index);
                if (curActiveBlock != -1)
                {
                    activeBlock.Image = bigBlocks[curActiveBlock];
                    lbActiveBlock.Text = String.Format("Label: {0:X}", curActiveBlock);
                }
                blocksScreen.Invalidate();
            }
        }

        private void mapScreen_MouseMove(object sender, MouseEventArgs ea)
        {
            var ee = ea.Location;
            if (ee.X < 0) { ee.X += 32768 * 2; }
            if (ee.Y < 0) { ee.Y += 32768 * 2; }

            if (selectionRect)
            {
                selectionMouseX = ee.X;
                selectionMouseY = ee.Y;
                mapScreen.Invalidate();
                return;
            }
            var screen = getActiveScreen();
            int width = screen.width;
            int dx = ee.X / bigBlocks[0].Width - 1;
            int dy = ee.Y / bigBlocks[0].Height;
            lbCoords.Text = String.Format("Coords:({0},{1})", dx, dy);

            bool curDeltaChanged = curDx != dx || curDy != dy;
            if (curDeltaChanged)
            {
                curDx = dx;
                curDy = dy;
            }
            if (curClicked)
            {
                if (dx == width)
                {
                    if (screenNo < ConfigScript.screensOffset[0].recCount - 1)
                    {
                        int index = dy * width;
                        var layer = getActiveLayer(screens[screenNo + 1]);
                        curActiveBlock = Utils.getBigTileNoFromScreen(layer.data, index);
                        Utils.setBigTileToScreen(layer.data, index, curActiveBlock);
                        dirty = true; updateSaveVisibility();
                    }
                }
                else if (dx == -1)
                {
                    if (screenNo > 0)
                    {
                        int index = dy * width + (width - 1);

                        var layer = getActiveLayer(screens[screenNo - 1]);
                        Utils.setBigTileToScreen(layer.data, index, curActiveBlock);
                        dirty = true; updateSaveVisibility();
                    }
                }
                else
                {
                    int index = dy * width + dx;
                    var layer = getActiveLayer(screens[screenNo]);
                    if (index < layer.data.Length)
                    {
                        Utils.setBigTileToScreen(layer.data, index, curActiveBlock);
                    }
                    dirty = true; updateSaveVisibility();
                }
            }
            mapScreen.Invalidate();
        }

        private void mapScreen_MouseLeave(object sender, EventArgs e)
        {
            lbCoords.Text = "Coords:()";
            curDx = Outside;
            curDy = Outside;
            curClicked = false;
            mapScreen.Invalidate();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            saveToFile();
        }

        private bool saveToFile()
        {
            ConfigScript.saveScreens(screens);
            dirty = !Globals.flushToFile(); updateSaveVisibility();
            return !dirty;
        }

        private void cbLevel_SelectedIndexChanged(object sender, EventArgs ev)
        {
            if (!UtilsGui.askToSave(ref dirty, saveToFile, returnCbLevelIndex))
            {
                updateSaveVisibility();
                return;
            }
            updateSaveVisibility();
            changeLevelIndex();
            var screen = getActiveScreen();
        }

        private void changeLevelIndex(bool reloadBlocks = false)
        {
            curActiveViewType = (MapViewType)cbViewType.SelectedIndex;
            reloadLevel(true, reloadBlocks);
        }

        private void returnCbLevelIndex()
        {
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UtilsGui.askToSave(ref dirty, saveToFile, returnCbLevelIndex))
            {
                updateSaveVisibility();
                e.Cancel = true;
            }
        }

        private void btSubeditor_Click(object sender, EventArgs e)
        {
            var button = (ToolStripButton)sender;
            subeditorOpen(subeditorsDict[button](), button);
        }

        private void cbScreenNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbScreenNo.SelectedIndex == -1)
                return;
            screenNo = cbScreenNo.SelectedIndex;
            resetMapScreenSize();
            mapScreen.Invalidate();
        }


        private void cbShowNeighbors_CheckedChanged(object sender, EventArgs e)
        {
            showNeiScreens = bttShowNei.Checked;
            mapScreen.Invalidate();
        }

        private bool openFile()
        {
            if (!UtilsGui.askToSave(ref dirty, saveToFile, returnCbLevelIndex))
            {
                updateSaveVisibility();
                return false;
            }
            updateSaveVisibility();
            var f = new OpenFile();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (!Globals.loadData(OpenFile.fileName, OpenFile.configName))
                {
                    Close();
                    return false;
                }
                fileLoaded = true;
                resetControls();
                setWindowText();
            }

            if (!fileLoaded)
            {
                return false;
            }

            return true;

        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            if (openFile())
            {
                changeLevelIndex();
            }
        }

        public void setDirty()
        {
            dirty = true;
            updateSaveVisibility();
        }

        private void updateSaveVisibility()
        {
            bttSave.Enabled = dirty;
        }

        private void cbShowGridlines_CheckedChanged(object sender, EventArgs e)
        {
            showGridlines = bttGridlines.Checked;
            mapScreen.Invalidate();
            blocksScreen.Invalidate();
        }


        private FormClosedEventHandler subeditorClosed(ToolStripItem enabledAfterCloseButton)
        {
            return delegate
            {
                enabledAfterCloseButton.Enabled = true;
                reloadLevel(true, true);
            };
        }

        public void subeditorOpen(Form f, ToolStripItem b, bool showDialog = false)
        {
            if (UtilsGui.askToSave(ref dirty, saveToFile, returnCbLevelIndex))
            {
                updateSaveVisibility();
                b.Enabled = false;
                f.FormClosed += subeditorClosed(b);
                if (showDialog)
                {
                    f.ShowDialog();
                }
                else
                {
                    f.Show();
                }
            }
        }

        public int curActiveBigBlockNo { get; private set; }

        public MapViewType curActiveViewType { get; private set; } = MapViewType.ObjType;
        public bool showGridlines { get; private set; }
        public int screenNo { get; private set; }

        public bool additionalRenderEnabled { get; private set; } = true;

        public Screen[] screens { get; private set; }

        public Image[] bigBlocks { get; private set; } = new Image[0];

        //warning! danger direct function. do not use it
        public void setScreens(Screen[] newScreens)
        {
            screens = newScreens;
        }

        private void mapScreen_MouseDown(object sender, MouseEventArgs ea)
        {
            var ee = ea.Location;

            //hack to WinAPI very big coordinates - convert signed to unsigned
            if (ee.X < 0) { ee.X += 32768 * 2; }
            if (ee.Y < 0) { ee.Y += 32768 * 2; }

            if (ea.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Alt)
                {
                    convertMouseToDxDy(ee, out selectionBeginX, out selectionBeginY);
                    selectionBeginMouseX = ee.X;
                    selectionBeginMouseY = ee.Y;
                    selectionRect = true;
                }
                else
                {
                    curClicked = true;
                    mapScreen_MouseMove(sender, ea);
                }
            }
        }

        private void mapScreen_MouseUp(object sender, MouseEventArgs ea)
        {
            var ee = ea.Location;

            //hack to WinAPI very big coordinates - convert signed to unsigned
            if (ee.X < 0) { ee.X += 32768 * 2; }
            if (ee.Y < 0) { ee.Y += 32768 * 2; }

            if (selectionRect)
            {
                convertMouseToDxDy(ee, out selectionEndX, out selectionEndY);
                if (selectionEndX < selectionBeginX)
                {
                    Utils.swap(ref selectionBeginX, ref selectionEndX);
                }
                if (selectionEndY < selectionBeginY)
                {
                    Utils.swap(ref selectionBeginY, ref selectionEndY);
                }
                int deltaX = selectionEndX - selectionBeginX + 1;
                int deltaY = selectionEndY - selectionBeginY + 1;
                int[][] tiles = new int[deltaY][];
                for (int arrs = 0; arrs < tiles.Length; arrs++)
                    tiles[arrs] = new int[deltaX];
                var curScreen = screens[screenNo];
                for (int i = 0; i < deltaX; i++)
                {
                    for (int j = 0; j < deltaY; j++)
                    {
                        int index = (selectionBeginY + j) * curScreen.width + (selectionBeginX + i);
                        tiles[j][i] = curScreen.layers[curActiveLayer].data[index];
                    }
                }
            }
            selectionRect = false;
            curClicked = false;
        }

        private void convertMouseToDxDy(Point e, out int dx, out int dy)
        {
            dx = e.X / bigBlocks[0].Width - 1;
            dy = e.Y / bigBlocks[0].Height;
        }

        public void reloadCallback()
        {
            bttReload_Click(null, new EventArgs());
        }

        private void bttReload_Click(object sender, EventArgs e)
        {
            if (UtilsGui.askToSave(ref dirty, saveToFile, returnCbLevelIndex))
            {
                if (!Globals.loadData(OpenFile.fileName, OpenFile.configName))
                {
                    return;
                }
                resetControls();
                reloadLevel(true, true);
                mapScreen.Invalidate();
            }
        }


        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void blocksScreen_Paint(object sender, PaintEventArgs e)
        {
            if (!fileLoaded)
                return;
            var g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            var renderParams = new MapEditor.RenderParams
            {
                bigBlocks = bigBlocks,
                visibleRect = UtilsGui.getVisibleRectangle(pnBlocks, blocksScreen),
                showBlocksGridlines = showGridlines,
                renderBlockFunc = MapEditor.renderBlocksOnPanelFunc
            };

            int blocksCount = bigBlocks.Length;
            MapEditor.renderAllBlocks(g, blocksScreen, curActiveBlock, blocksCount, renderParams);
        }

        private void blocksScreen_MouseDown(object sender, MouseEventArgs e)
        {
            var p = blocksScreen.PointToClient(Cursor.Position);
            int x = p.X, y = p.Y;
            int tileSizeX = bigBlocks[0].Width;
            int tileSizeY = bigBlocks[0].Height;
            int tx = x / tileSizeX, ty = y / tileSizeY;
            int maxtX = blocksScreen.Width / tileSizeX;
            int index = ty * maxtX + tx;
            int maxIndex = bigBlocks.Length;
            if ((tx < 0) || (tx >= maxtX) || (index < 0) || (index >= maxIndex))
            {
                return;
            }

            activeBlock.Image = bigBlocks[index];
            curActiveBlock = index;
            lbActiveBlock.Text = String.Format("Label: ({0:X})", index);
            blocksScreen.Invalidate();
        }

        private void pnBlocks_SizeChanged(object sender, EventArgs e)
        {
            updateBlocksImages();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            splitContainer1.Width = Width - 21;
            splitContainer1.Height = Height - 81;
        }

        private void FormMain_LocationChanged(object sender, EventArgs e)
        {
            OnResize(e);
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            pnBlocks.Width = splitContainer1.Panel1.Width - pnElements.Width - 10;
            pnBlocks.Height = splitContainer1.Panel1.Height - 10;
            blocksScreen.Width = pnBlocks.Width;
            updateBlocksImages();
        }

        public void clearSubeditorButtons()
        {
            toolStrip1.Items.Clear();
            ToolStripItem[] items = {
                bttOpen,
                bttSave,
                bttReload,
                bttBlocks,
                bttShowNei,
                bttGridlines,
            };

            toolStrip1.Items.AddRange(items);
        }

        private void setWindowText()
        {
            Text = String.Format("CAD Editor v5.3 - {0}", OpenFile.fileName);
        }

        private Screen getActiveScreen()
        {
            return screens[screenNo];
        }

        private BlockLayer getActiveLayer(Screen curScreen)
        {
            return curScreen.layers[curActiveLayer];
        }
    }
}
