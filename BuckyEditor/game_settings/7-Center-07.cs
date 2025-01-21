using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xf6e2; }
  public int getScreenCount() { return 7; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return new[] {0x11AA3, 0x11AB5, 0x11AC7, 0x11AD9}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x12000, 0x12800, 0x13000, 0x13800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0xB800}; }
}