using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x9060; }
  public int getScreenCount() { return 2; }
  public int getMetatileAddress()    { return 0x8011; }
  public int getBlocksCount()           { return 157; }
  public int getPalBytesAddr()          { return 0x89e1; }
  public int[] getPalAddresses()            { return 0x117F7; }
  public int[] getPatternTableAddresses()   { return new[] {0x1F000, 0x3000}; }
}