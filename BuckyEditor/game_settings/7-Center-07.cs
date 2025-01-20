using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xf6e2; }
  public int getScreenCount() { return 7; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return 0x11AD9; } 
  public int[] getPatternTableAddresses()   { return new[] {0x12000, 0xB800}; }
}