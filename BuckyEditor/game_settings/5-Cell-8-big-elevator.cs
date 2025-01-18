using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xe145, 1 , 8*87, 8, 87);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xd2d8, 1  , 0x1000);  }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int getPalAddress()            { return 0x11971; } 
  public int[] getPatternTableAddresses()   { return new[] {0x5000, 0x7800}; }
}