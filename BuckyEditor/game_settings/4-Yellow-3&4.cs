using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xcd18; }
  public int getScreenCount() { return 2; }
  public int getMetatileAddress()    { return 0xc011; }
  public int getBlocksCount()           { return 156; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int[] getPalAddresses()            { return 0x11905; }
  public int[] getPatternTableAddresses()   { return new[] {0x3000, 0x5800}; }
}