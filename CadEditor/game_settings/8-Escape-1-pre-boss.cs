using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x3858, 19 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x30e2, 1  , 0x1000);  }
  public int getBlocksCount()           { return 208; }
  public int getPalBytesAddr()          { return 0x3742; }
  public int getPalAddress()            { return 0x11B8D; } 
  public int[] getPatternTableAddresses()   { return new[] {0xC000, 0xC000}; }
}