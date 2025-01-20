using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xaadf; }
  public int getScreenCount() { return 2; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int[] getPalAddresses()            { return new[] {0x118BD}; }
  public int[] getPatternTableAddresses()   { return new[] {0x7000, 0x3800}; }
}