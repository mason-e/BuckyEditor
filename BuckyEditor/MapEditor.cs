﻿using System.Drawing;
using System.Windows.Forms;

namespace BuckyEditor
{
    public class MapEditor
    {
        public static void render(Graphics g, Screen[] screens, int scrNo, RenderParams renderParams)
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            var curScreen = screens[scrNo];
            for (int layerIndex = 0; layerIndex < curScreen.layers.Length; layerIndex++)
            {
                var layer = screens[scrNo].layers[layerIndex];
                renderLayer(g, layer, renderParams);
            }

            if (renderParams.showBorder)
            {
                int tileSizeX = renderParams.bigBlocks[0].Width;
                int tileSizeY = renderParams.bigBlocks[0].Height;
                g.DrawRectangle(new Pen(Color.Green, 4.0f), new Rectangle(tileSizeX, 0, tileSizeX * renderParams.width, tileSizeY * renderParams.height));
            }
        }

        private static void renderLayer(Graphics g, BlockLayer layer, RenderParams renderParams)
        {
            bool needRenderLayer = layer != null && layer.showLayer;
            if (!needRenderLayer)
            {
                return;
            }

            int tileSizeX = renderParams.getTileSizeX();
            int tileSizeY = renderParams.getTileSizeY();

            int size = renderParams.getLayerSize();
            for (int i = 0; i < size; i++)
            {
                int bigBlockNo = Utils.getBigTileNoFromScreen(layer.data, i);
                Rectangle tileRect = new Rectangle((i % renderParams.width) * tileSizeX + renderParams.leftMargin, i / renderParams.width * tileSizeY + renderParams.topMargin, tileSizeX, tileSizeY);
                renderParams.renderBlock(g, bigBlockNo, tileRect);
            }
        }

        private static void renderBlockOnPanel(Graphics g, int bigBlockNo, Rectangle tileRect, RenderParams renderParams)
        {
            if (bigBlockNo > -1 && bigBlockNo < renderParams.bigBlocks.Length)
                g.DrawImage(renderParams.bigBlocks[bigBlockNo], tileRect);
            else
                g.FillRectangle(Brushes.White, tileRect);

            if (renderParams.showBlocksGridlines)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(255, 255, 255, 255)), tileRect);
            }
        }

        public static RenderParams.RenderBlockFunc renderBlocksOnPanelFunc = renderBlockOnPanel;

        public static void renderAllBlocks(Graphics g, PictureBox parentControl, int activeBlock, int renderBlocksCount, RenderParams renderParams)
        {
            int tileSizeX = renderParams.getTileSizeX();
            int tileSizeY = renderParams.getTileSizeY();
            int width = parentControl.Width / tileSizeX;
            if (width == 0)
            {
                return;
            }

            for (int bigBlockNo = 0; bigBlockNo < renderBlocksCount; bigBlockNo++)
            {
                var tileRect = new Rectangle((bigBlockNo % width) * tileSizeX, bigBlockNo / width * tileSizeY, tileSizeX, tileSizeY);
                if (renderParams.needRenderTileRect(tileRect))
                {
                    renderParams.renderBlock(g, bigBlockNo, tileRect);

                    //additinal border render for active block
                    if (bigBlockNo == activeBlock)
                    {
                        g.DrawRectangle(new Pen(Brushes.Red, 3.0f), tileRect);
                    }
                }
            }
        }

        public class RenderParams
        {
            public RenderParams()
            {
                renderBlockFunc = renderBlockDefault;
            }

            public RenderParams(RenderParams other)
            {
                bigBlocks = other.bigBlocks;
                visibleRect = other.visibleRect;
                showBorder = other.showBorder;
                showBlocksGridlines = other.showBlocksGridlines;
                leftMargin = other.leftMargin;
                topMargin = other.topMargin;
                width = other.width;
                height = other.height;
                additionalRenderEnabled = other.additionalRenderEnabled;
                renderBlockFunc = other.renderBlockFunc;
            }

            public Image[] bigBlocks { get; set; }
            public Rectangle? visibleRect { get; set; }
            public bool showBorder { get; set; }
            public bool showBlocksGridlines { get; set; }
            public int leftMargin { get; set; }
            public int topMargin { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool additionalRenderEnabled { get; set; }

            public delegate void RenderBlockFunc(Graphics g, int bigBlockNo, Rectangle tileRect, RenderParams renderParams);

            public RenderBlockFunc renderBlockFunc { get; set; }

            public int getTileSizeX()
            {
                if (bigBlocks == null || bigBlocks?.Length < 1)
                {
                    return -1;
                }

                return bigBlocks[0].Width;
            }

            public int getTileSizeY()
            {
                if (bigBlocks == null || bigBlocks?.Length < 1)
                {
                    return -1;
                }

                return bigBlocks[0].Height;
            }

            public int getLayerSize()
            {
                return width * height;
            }

            public bool needRenderTileRect(Rectangle tileRect)
            {
                return visibleRect == null ||
                       visibleRect.Value.Contains(tileRect) ||
                       visibleRect.Value.IntersectsWith(tileRect);
            }

            private void renderBlockDefault(Graphics g, int bigBlockNo, Rectangle tileRect, RenderParams renderParams)
            {
                if (bigBlockNo > -1 && bigBlockNo < bigBlocks.Length)
                {
                    g.DrawImage(bigBlocks[bigBlockNo], tileRect);
                    if (showBlocksGridlines)
                    {
                        g.DrawRectangle(new Pen(Color.FromArgb(255, 255, 255, 255)), tileRect);
                    }
                }
                //else
                //    g.FillRectangle(Brushes.White, tileRect);
            }

            public void renderBlock(Graphics g, int bigBlockNo, Rectangle tileRect)
            {
                if (needRenderTileRect(tileRect))
                {
                    renderBlockFunc(g, bigBlockNo, tileRect, this);
                }
            }
        }
    }
}
