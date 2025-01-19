using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xbb5f; }
  public int getScreenCount() { return 5; }
  public int getMetatileAddress()    { return 0xadaf; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xb4cf; }
  public int getPalAddress()            { return 0x11A5B; } 
  public int[] getPatternTableAddresses()   { return new[] {0xA000, 0x12000}; }
}