using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xf622; }
  public int getScreenCount() { return 4; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return new[] {0x11A91}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x0800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0xB800}; }
}