using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x9e71, 12 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x9188, 1  , 0x1000);  }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int getPalAddress()            { return 0x11875; }
  public int[] getPatternTableAddresses()   { return new[] {0x9800, 0x0}; }
}