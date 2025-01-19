using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xad4f; }
  public int getScreenCount() { return 1; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getBlocksCount()           { return 100; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int getPalAddress()            { return 0x118E1; }
  public int[] getPatternTableAddresses()   { return new[] {0x4800, 0x1000}; }
}