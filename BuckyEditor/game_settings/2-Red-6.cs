using BuckyEditor;
using System;

// this one might not work right - could be that moving platforms aren't stored like regular tiles
public class Data 
{ 
  public int getLevelStartAddr() { return 0xa0b1; }
  public int getScreenCount() { return 6; }
  public int getMetatileAddress()    { return 0x9188; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int[] getPalAddresses()            { return new[] {0x11899}; }
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x4000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x1000, 0x1800, 0x2000}; }
}