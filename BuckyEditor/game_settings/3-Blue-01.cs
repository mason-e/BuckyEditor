using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xa86f; }
  public int getScreenCount() { return 6; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int[] getPalAddresses()            { return 0x118AB; }
  public int[] getPatternTableAddresses()   { return new[] {0x12000, 0x3800}; }
}