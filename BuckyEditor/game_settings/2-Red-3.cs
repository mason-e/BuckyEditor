using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x9ad1, 1 , 8*62, 8, 62);   }
  
  public int getMetatileAddress()    { return 0x9188; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int getPalAddress()            { return 0x11851; } 
  public int[] getPatternTableAddresses()   { return new[] {0x6000, 0x1000}; }
}