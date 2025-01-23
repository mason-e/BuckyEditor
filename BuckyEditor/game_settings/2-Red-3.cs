using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x9ad1; }
  public int getScreenCount() { return 1; }
  public int getScreenHeight() { return 62; }
  public int getMetatileAddress()    { return 0x9188; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int[] getPalAddresses()            { return new[] {0x11851}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x6000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x1000, 0x1800, 0x2000}; }
}