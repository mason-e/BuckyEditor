using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xdf7d, 4 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xd2d8, 1  , 0x1000);  }
  public int getBlocksCount()           { return 132; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int getPalAddress()            { return 0x11A01; } 
  public int[] getPatternTableAddresses()   { return new[] {0x5000, 0x0}; }
}