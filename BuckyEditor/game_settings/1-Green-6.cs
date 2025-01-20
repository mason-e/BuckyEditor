using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x9130; }
  public int getScreenCount() { return 1; } 
  public int getScreenHeight() { return 11; }
  public int getMetatileAddress()    { return 0x8011; }
  public int getBlocksCount()           { return 157; }
  public int getPalBytesAddr()          { return 0x89e1; }
  public int[] getPalAddresses()            { return new[] {0x11809}; }
  public int[] getPatternTableAddresses()   { return new[] {0x1F000, 0x7000}; }
}