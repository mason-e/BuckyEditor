using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x3BE8, 4 , 8*6, 8, 6);   }
  
  public int getMetatileAddress()    { return 0x30e2; }
  public int getBlocksCount()           { return 208; }
  public int getPalBytesAddr()          { return 0x3742; }
  public int getPalAddress()            { return 0x11BC3; } 
  public int[] getPatternTableAddresses()   { return new[] {0xC000, 0xC800}; }
}