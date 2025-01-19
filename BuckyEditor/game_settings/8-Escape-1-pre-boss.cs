using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x3858; }
  public int getScreenCount() { return 19; }
  public int getMetatileAddress()    { return 0x30e2; }
  public int getBlocksCount()           { return 208; }
  public int getPalBytesAddr()          { return 0x3742; }
  public int getPalAddress()            { return 0x11B8D; } 
  public int[] getPatternTableAddresses()   { return new[] {0xC000, 0xC000}; }
}