using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xcd18, 2 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xc011, 1  , 0x1000);  }
  public int getBlocksCount()           { return 156; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int getPalAddress()            { return 0x11905; }
  public int[] getPatternTableAddresses()   { return new[] {0x3000, 0x5800}; }
}