using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xfad2, 1 , 8*6, 8, 6);   }
  
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 208; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int getPalAddress()            { return 0x11B57; } 
  public int[] getPatternTableAddresses()   { return new[] {0x1E000, 0x1E800}; }
}