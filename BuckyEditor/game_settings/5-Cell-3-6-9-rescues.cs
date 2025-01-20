using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xe0b5; }
  public int getScreenCount() { return 3; }
  public int getMetatileAddress()    { return 0xd2d8; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int[] getPalAddresses()            { return 0x1195F; } 
  public int[] getPatternTableAddresses()   { return new[] {0x5000, 0x12000}; }
}