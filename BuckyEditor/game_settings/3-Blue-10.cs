using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xad4f; }
  public int getScreenCount() { return 1; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getBlocksCount()           { return 100; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int[] getPalAddresses()            { return new[] {0x118E1}; }
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x4800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x1000, 0x1800, 0x2000}; }
}