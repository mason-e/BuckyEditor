using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xab3f, 1 , 8*36, 8, 36);   }
  
  public int getMetatileAddress()    { return 0xa181; }
  public int getBlocksCount()           { return 95; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int getPalAddress()            { return 0x118AB; }
  public int[] getPatternTableAddresses()   { return new[] {0x4800, 0x3800}; }
}