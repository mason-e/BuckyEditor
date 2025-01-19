using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xb65f, 1 , 8*46, 8, 46);   }
  
  public int getMetatileAddress()    { return 0xadaf; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xb4cf; }
  public int getPalAddress()            { return 0x11A25; } 
  public int[] getPatternTableAddresses()   { return new[] {0xA000, 0xA800}; }
}