using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x8cc0; }
  public int getScreenCount() { return 6; }
  public int getMetatileAddress()    { return 0x8011; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x89e1; }
  public int[] getPalAddresses()            { return new[] {0x117E5}; }
  public int[] getPatternTableAddresses()   { return new[] {0x0, 0x0800}; }
}