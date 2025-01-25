using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xa86f; }
  public int getScreenCount() { return 6; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getMetatileCount()           { return 85; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int[] getPalAddresses()            { return new[] {0x118AB}; }
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x12000, 0x12800, 0x13000, 0x13800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x3800}; }
}