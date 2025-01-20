using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xcb98; }
  public int getScreenCount() { return 8; }
  public int getMetatileAddress()    { return 0xc011; }
  public int getBlocksCount()           { return 116; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int[] getPalAddresses()            { return new[] {0x118F3}; }
  public int[] getPatternTableAddresses()   { return new[] {0x3000, 0x5800}; }
}