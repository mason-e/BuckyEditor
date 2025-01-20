using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xcd78; }
  public int getScreenCount() { return 1; }
  public int getScreenHeight() { return 22; }
  public int getMetatileAddress()    { return 0xc011; }
  public int getBlocksCount()           { return 156; }
  public int getPalBytesAddr()          { return 0xca21; }
  public int[] getPalAddresses()            { return new[] {0x11905}; }
  public int[] getPatternTableAddresses()   { return new[] {0x3000, 0x5800}; }
}