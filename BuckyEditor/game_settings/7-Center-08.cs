using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xf292; }
  public int getScreenCount() { return 4; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 180; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return 0x11AEB; } 
  public int[] getPatternTableAddresses()   { return new[] {0x8000, 0x8800}; }
}