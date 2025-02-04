using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x3ca8; }
  public int getScreenCount() { return 3; }
  public int getMetatileAddress()    { return 0x30e2; }
  public int getMetatileCount()           { return 208; }
  public int getPalBytesAddr()          { return 0x3742; }
  public int[] getPalAddresses()            { return new[] {0x11BE7, 0x11BF9}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0xC000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x2000}; }
}