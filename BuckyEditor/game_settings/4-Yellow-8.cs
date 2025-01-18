using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xd278, 1, 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xc011, 1  , 0x1000);  }
  public int getBlocksCount()           { return 164; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int getPalAddress()            { return 0x1193B; }
  public int[] getPatternTableAddresses()   { return new[] {0x6800, 0x1800}; }
}