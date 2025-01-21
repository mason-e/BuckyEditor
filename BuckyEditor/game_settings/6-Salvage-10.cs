using BuckyEditor;
using System;

// ground isn't in this data, not sure why or where to find it yet
public class Data 
{ 
  public int getLevelStartAddr() { return 0xbc4f; }
  public int getScreenCount() { return 1; }
  public int getScreenHeight() { return 10; }
  public int getMetatileAddress()    { return 0xadaf; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xb4cf; }
  public int[] getPalAddresses()            { return new[] {0x11A7F}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x9000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x9800}; }
}