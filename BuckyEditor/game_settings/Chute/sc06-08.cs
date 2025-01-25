using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xba3f; }
  public int getScreenCount() { return 6; }
  public int getMetatileAddress()    { return 0xadaf; }
  public int getMetatileCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xb4cf; }
  public int[] getPalAddresses()            { return new[] {0x11A49}; } 
  public int[] getPatternTableFirstHalfAddr() { return new[] {0xA000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x12000, 0x12800, 0x13000, 0x13800}; }
}