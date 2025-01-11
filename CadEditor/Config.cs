using CadEditor;
using System.Collections.Generic;
using System.Drawing;

public class Config
{
  public string getFileName()      { return ""; }
  public string getConfigName()    { return ""; }
  public Color[] getNesColors()
  {
    var NesColors = new Color[0x40];
    NesColors[0] = Color.FromArgb(102, 102, 102);
    NesColors[1] = Color.FromArgb(0, 42, 136);
    NesColors[2] = Color.FromArgb(20, 18, 167);
    NesColors[3] = Color.FromArgb(59, 0, 164);
    NesColors[4] = Color.FromArgb(92, 0, 126);
    NesColors[5] = Color.FromArgb(110, 0, 64);
    NesColors[6] = Color.FromArgb(108, 6, 0);
    NesColors[7] = Color.FromArgb(86, 29, 0);
    NesColors[8] = Color.FromArgb(51, 53, 0);
    NesColors[9] = Color.FromArgb(11, 72, 0);
    NesColors[0xA] = Color.FromArgb(0, 82, 0);
    NesColors[0xB] = Color.FromArgb(0, 79, 8);
    NesColors[0xC] = Color.FromArgb(0, 64, 77);
    NesColors[0xD] = Color.FromArgb(0, 0, 0);
    NesColors[0xE] = Color.FromArgb(0, 0, 0);
    NesColors[0xF] = Color.FromArgb(0, 0, 0);

    NesColors[0x10] = Color.FromArgb(173, 173, 173);
    NesColors[0x11] = Color.FromArgb(21, 95, 217);
    NesColors[0x12] = Color.FromArgb(64, 64, 255);
    NesColors[0x13] = Color.FromArgb(117, 39, 254);
    NesColors[0x14] = Color.FromArgb(160, 26, 204);
    NesColors[0x15] = Color.FromArgb(183, 30, 123);
    NesColors[0x16] = Color.FromArgb(181, 49, 32);
    NesColors[0x17] = Color.FromArgb(153, 78, 0);
    NesColors[0x18] = Color.FromArgb(107, 109, 0);
    NesColors[0x19] = Color.FromArgb(56, 135, 0);
    NesColors[0x1A] = Color.FromArgb(12, 147, 0);
    NesColors[0x1B] = Color.FromArgb(0, 143, 50);
    NesColors[0x1C] = Color.FromArgb(0, 124, 141);
    NesColors[0x1D] = Color.FromArgb(0, 0, 0);
    NesColors[0x1E] = Color.FromArgb(0, 0, 0);
    NesColors[0x1F] = Color.FromArgb(0, 0, 0);

    NesColors[0x20] = Color.FromArgb(255, 254, 255);
    NesColors[0x21] = Color.FromArgb(100, 176, 255);
    NesColors[0x22] = Color.FromArgb(146, 144, 255);
    NesColors[0x23] = Color.FromArgb(198, 118, 255);
    NesColors[0x24] = Color.FromArgb(243, 106, 255);
    NesColors[0x25] = Color.FromArgb(254, 110, 204);
    NesColors[0x26] = Color.FromArgb(254, 129, 112);
    NesColors[0x27] = Color.FromArgb(234, 158, 34);
    NesColors[0x28] = Color.FromArgb(188, 190, 0);
    NesColors[0x29] = Color.FromArgb(136, 216, 0);
    NesColors[0x2A] = Color.FromArgb(92, 228, 48);
    NesColors[0x2B] = Color.FromArgb(69, 224, 130);
    NesColors[0x2C] = Color.FromArgb(75, 205, 222);
    NesColors[0x2D] = Color.FromArgb(79, 79, 79);
    NesColors[0x2E] = Color.FromArgb(0, 0, 0);
    NesColors[0x2F] = Color.FromArgb(0, 0, 0);

    NesColors[0x30] = Color.FromArgb(255, 254, 255);
    NesColors[0x31] = Color.FromArgb(192, 223, 255);
    NesColors[0x32] = Color.FromArgb(211, 210, 255);
    NesColors[0x33] = Color.FromArgb(232, 200, 255);
    NesColors[0x34] = Color.FromArgb(215, 194, 255);
    NesColors[0x35] = Color.FromArgb(254, 196, 234);
    NesColors[0x36] = Color.FromArgb(254, 204, 197);
    NesColors[0x37] = Color.FromArgb(247, 216, 165);
    NesColors[0x38] = Color.FromArgb(228, 229, 148);
    NesColors[0x39] = Color.FromArgb(207, 239, 150);
    NesColors[0x3A] = Color.FromArgb(189, 244, 171);
    NesColors[0x3B] = Color.FromArgb(179, 243, 204);
    NesColors[0x3C] = Color.FromArgb(181, 235, 242);
    NesColors[0x3D] = Color.FromArgb(184, 184, 184);
    NesColors[0x3E] = Color.FromArgb(0, 0, 0);
    NesColors[0x3F] = Color.FromArgb(0, 0, 0);
    
    return NesColors;
  }
}