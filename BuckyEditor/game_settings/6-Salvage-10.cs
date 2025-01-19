using BuckyEditor;
using System;

// ground isn't in this data, not sure why or where to find it yet
public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xbc4f, 1 , 8*10, 8, 10);   }
  
  public int getMetatileAddress()    { return 0xadaf; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xb4cf; }
  public int getPalAddress()            { return 0x11A7F; } 
  public int[] getPatternTableAddresses()   { return new[] {0x9000, 0x9800}; }
}