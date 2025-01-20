using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xab3f; }
  public int getScreenCount() { return 1; }
  public int getScreenHeight() { return 36; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getBlocksCount()           { return 95; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int[] getPalAddresses()            { return 0x118AB; }
  public int[] getPatternTableAddresses()   { return new[] {0x4800, 0x3800}; }
}