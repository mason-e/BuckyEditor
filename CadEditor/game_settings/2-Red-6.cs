using CadEditor;
using System;

// this one might not work right - could be that moving platforms aren't stored like regular tiles
public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xa0b1, 6 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x9188, 1  , 0x1000);  }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int getPalAddress()            { return 0x11899; }
  public int[] getPatternTableAddresses()   { return new[] {0x4000, 0x1800}; }
}