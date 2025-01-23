using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xdb8d; }
  public int getScreenCount() { return 10; }
  public int getMetatileAddress()    { return 0xd2d8; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int[] getPalAddresses()            { return new[] {0x1195F}; }  
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x5000}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x12000, 0x12800, 0x13000, 0x13800}; }
}
