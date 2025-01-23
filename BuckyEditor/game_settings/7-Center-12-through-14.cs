using BuckyEditor;
using System;

// each act uses the same set of screens with different snakes
public class Data 
{ 
  public int getLevelStartAddr() { return 0xfa72; }
  public int getScreenCount() { return 2; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return new[] {0x11AFD}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x12000, 0x12800, 0x13000, 0x13800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0xB800}; }
}