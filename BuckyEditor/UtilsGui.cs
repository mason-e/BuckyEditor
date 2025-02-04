﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace BuckyEditor
{
    public static class UtilsGui
    {
        public static void setCbItemsCount(ComboBox cb, int count, int first = 0, bool inHex = false)
        {
            cb.Items.Clear();
            if (!inHex)
            {
                for (int i = 0; i < count; i++)
                    cb.Items.Add(first + i);
            }
            else
            {
                for (int i = 0; i < count; i++)
                    cb.Items.Add(String.Format("{0:X}", first + i));
            }
        }

        public static void setCbIndexWithoutUpdateLevel(ComboBox cb, EventHandler ev, int index = 0)
        {
            cb.SelectedIndexChanged -= ev;
            cb.SelectedIndex = index;
            cb.SelectedIndexChanged += ev;
        }


        public static void resizeBlocksScreen(Image[] bigBlocks, PictureBox blocksScreen, int blockWidth, int blockHeight)
        {
            if (bigBlocks.Length == 0)
            {
                return;
            }
            int blocksOnRow = blocksScreen.Width / blockWidth;
            if (blocksOnRow == 0)
            {
                blocksOnRow = 1;
            }
            int blocksOnCol = (int)Math.Ceiling(bigBlocks.Length * 1.0f / blocksOnRow);
            blocksScreen.Height = blocksOnCol * blockHeight;
        }

        public delegate bool SaveFunction();
        public delegate void ReturnComboBoxIndexFunction();
        public static bool askToSave(ref bool dirty, SaveFunction saveToFile, ReturnComboBoxIndexFunction returnCbLevelIndex)
        {
            if (!dirty)
                return true;
            DialogResult dr = MessageBox.Show("Level was changed. Do you want to save current level?", "Save", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Cancel)
            {
                returnCbLevelIndex?.Invoke();
                return false;
            }
            else if (dr == DialogResult.Yes)
            {
                if (!saveToFile())
                {
                    returnCbLevelIndex?.Invoke();
                    return false;
                }
                return true;
            }
            else
            {
                dirty = false;
                return true;
            }
        }

        public static Rectangle getVisibleRectangle(Control panel, Control insideControl)
        {
            Rectangle rect = panel.RectangleToScreen(panel.ClientRectangle);
            while (panel != null)
            {
                rect = Rectangle.Intersect(rect, panel.RectangleToScreen(panel.ClientRectangle));
                panel = panel.Parent;
            }
            rect = insideControl.RectangleToClient(rect);
            return rect;
        }
    }
}
