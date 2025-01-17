using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xb7cf, 13 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xadaf, 1  , 0x1000);  }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xb4cf; }
  public int getPalAddress()            { return 0x11A37; } 
  public int[] getPatternTableAddresses()   { return new[] {0xA000, 0xA800}; }
}