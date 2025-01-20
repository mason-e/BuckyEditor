using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xac5f; }
  public int getScreenCount() { return 5; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getBlocksCount()           { return 100; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int[] getPalAddresses()            { return new[] {0x118AB}; }
  public int[] getPatternTableAddresses()   { return new[] {0x4800, 0x3800}; }
}