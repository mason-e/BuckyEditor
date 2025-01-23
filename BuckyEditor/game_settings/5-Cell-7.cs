using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xdf7d; }
  public int getScreenCount() { return 4; }
  public int getMetatileAddress()    { return 0xd2d8; }
  public int getBlocksCount()           { return 132; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int[] getPalAddresses()            { return new[] {0x11A01}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x5000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] { 0x0000, 0x1D800, 0x1D000, 0x1C800, 0x1C000, 0x1B800, 0x1B000, 0x1A800, 0x1A000, 0xF800, 0xF000, 0xE800, 0xE000, 0x8000, 0x7000, 0x0800 }; }
}