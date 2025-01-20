using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xb7cf; }
  public int getScreenCount() { return 13; }
  public int getMetatileAddress()    { return 0xadaf; }
  public int getBlocksCount()           { return 124; }
  public int getPalBytesAddr()          { return 0xb4cf; }
  public int[] getPalAddresses()            { return new[] {0x11A37}; } 
  public int[] getPatternTableAddresses()   { return new[] {0xA000, 0xA800}; }
}