using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xdf7d; }
  public int getScreenCount() { return 4; }
  public int getMetatileAddress()    { return 0xd2d8; }
  public int getBlocksCount()           { return 132; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int[] getPalAddresses()            { return 0x11A01; } 
  public int[] getPatternTableAddresses()   { return new[] {0x5000, 0x0}; }
}