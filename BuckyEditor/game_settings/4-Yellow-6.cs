using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xce28; }
  public int getScreenCount() { return 6; }
  public int getMetatileAddress()    { return 0xc011; }
  public int getMetatileCount()           { return 164; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int[] getPalAddresses()            { return new[] {0x11929}; }
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x6800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x7000}; }
}