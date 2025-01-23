using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xcd18; }
  public int getScreenCount() { return 2; }
  public int getMetatileAddress()    { return 0xc011; }
  public int getMetatileCount()           { return 156; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int[] getPalAddresses()            { return new[] {0x11905}; }
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x3000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x5800}; }
}