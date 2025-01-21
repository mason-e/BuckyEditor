using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x3858; }
  public int getScreenCount() { return 19; }
  public int getMetatileAddress()    { return 0x30e2; }
  public int getBlocksCount()           { return 208; }
  public int getPalBytesAddr()          { return 0x3742; }
  public int[] getPalAddresses()            { return new[] {0x11B69, 0x11B7B, 0x11B8D, 0x11B9F}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0xC000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0xC000, 0xC800, 0x7800, 0x8800, 0xD000, 0xF000, 0xF800, 0x1E000}; }
}