using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xf6e2, 7 , 8*6, 8, 6);   }
  
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int getPalAddress()            { return 0x11AD9; } 
  public int[] getPatternTableAddresses()   { return new[] {0x12000, 0xB800}; }
}