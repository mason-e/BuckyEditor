using BuckyEditor;
using System;

public class Data 
{ 
  public int getLevelStartAddr() { return 0xfad2; }
  public int getScreenCount() { return 1; }
  public int getMetatileAddress()    { return 0xe3fd; }
  public int getBlocksCount()           { return 208; }
  public int getPalBytesAddr()          { return 0xf12d; }
  public int[] getPalAddresses()            { return new[] {0x11B21, 0x11B33, 0x11B45, 0x11B57}; } 
  public int[] getPatternTableAddresses()   { return new[] {0x1E000, 0x1E800}; }
}