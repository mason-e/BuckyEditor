using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xf352; }
  public int getScreenCount() { return 15; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getMetatileCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return new[] {0x11AA3, 0x11AB5, 0x11AC7, 0x11AD9}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0xB000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0xB800}; }
}