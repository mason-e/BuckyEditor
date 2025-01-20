using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xd278; }
  public int getScreenCount() { return 1; }
  public int getMetatileAddress()    { return 0xc011; }
  public int getBlocksCount()           { return 164; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int[] getPalAddresses()            { return new[] {0x1193B}; }
  public int[] getPatternTableAddresses()   { return new[] {0x6800, 0x1800}; }
}