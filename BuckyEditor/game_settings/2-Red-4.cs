using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0x9cc1; }
  public int getScreenCount() { return 7; }
  public int getMetatileAddress()    { return 0x9188; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x96b8; }
  public int getPalAddress()            { return 0x11863; }
  public int[] getPatternTableAddresses()   { return new[] {0x4000, 0x1000}; }
}