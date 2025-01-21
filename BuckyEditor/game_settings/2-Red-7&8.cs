using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x9e71; }
  public int getScreenCount() { return 12; }
  public int getMetatileAddress()    { return 0x9188; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int[] getPalAddresses()            { return new[] {0x11875}; }
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x9800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] { 0x0000, 0x1D800, 0x1D000, 0x1C800, 0x1C000, 0x1B800, 0x1B000, 0x1A800, 0x1A000, 0xF800, 0xF000, 0xE800, 0xE000, 0x8000, 0x7000, 0x0800 }; }
}