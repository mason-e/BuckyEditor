using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xf832; }
  public int getScreenCount() { return 12; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getMetatileCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return new[] {0x11AEB}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x8000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x8800}; }
}