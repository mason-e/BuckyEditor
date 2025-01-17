using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xac5f, 5 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xa181, 1  , 0x1000);  }
  public int getBlocksCount()           { return 100; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int getPalAddress()            { return 0x118AB; }
  public int[] getPatternTableAddresses()   { return new[] {0x4800, 0x3800}; }
}