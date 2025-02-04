using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xe03d; }
  public int getScreenCount() { return 1; }
  public int getScreenHeight() { return 15; }
  public int getMetatileAddress()    { return 0xd2d8; }
  public int getMetatileCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int[] getPalAddresses()            { return new[] {0x11971}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x5000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x7800}; }
}