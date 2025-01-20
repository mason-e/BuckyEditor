using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xcf48; }
  public int getScreenCount() { return 17; }
  public int getMetatileAddress()    { return 0xc011; }
  public int getBlocksCount()           { return 164; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int[] getPalAddresses()            { return 0x1194D; }
  public int[] getPatternTableAddresses()   { return new[] {0x9000, 0x5800}; }
}