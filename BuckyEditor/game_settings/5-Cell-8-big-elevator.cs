using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xe145; }
  public int getScreenCount() { return 1; }
  public int getScreenHeight() { return 87; }
  public int getMetatileAddress()    { return 0xd2d8; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xdaa8; }
  public int getPalAddress()            { return 0x11971; } 
  public int[] getPatternTableAddresses()   { return new[] {0x5000, 0x7800}; }
}