using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xcf48, 17 , 8*6, 8, 6);   }
  
  public int getMetatileAddress()    { return 0xc011; }
  public int getBlocksCount()           { return 164; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int getPalAddress()            { return 0x1194D; }
  public int[] getPatternTableAddresses()   { return new[] {0x9000, 0x5800}; }
}