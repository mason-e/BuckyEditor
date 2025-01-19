using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x9e11, 2 , 8*6, 8, 6);   }
  
  public int getMetatileAddress()    { return 0x9188; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int getPalAddress()            { return 0x11899; }
  public int[] getPatternTableAddresses()   { return new[] {0x4000, 0x1000}; }
}