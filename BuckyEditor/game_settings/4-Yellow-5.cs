using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xcd78, 1 , 8*22, 8, 22);   }
  
  public int getMetatileAddress()    { return 0xc011; }
  public int getBlocksCount()           { return 156; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int getPalAddress()            { return 0x11905; }
  public int[] getPatternTableAddresses()   { return new[] {0x3000, 0x5800}; }
}