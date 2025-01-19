using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x97b9; }
  public int getScreenCount() { return 6; }
  public int getMetatileAddress()    { return 0x9188; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int getPalAddress()            { return 0x1183F; }
  public int[] getPatternTableAddresses()   { return new[] {0x6000, 0x1000}; }
}