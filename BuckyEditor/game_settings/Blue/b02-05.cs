using BuckyEditor;
using System;

// First two screens repeat 3 acts for the robo snakes, and are stored in
// reverse order in memory of how they show in game
public class Data 
{ 
  public int getLevelStartAddr() { return 0xa98f; }
  public int getScreenCount() { return 7; }
  public int getMetatileAddress()    { return 0xa181; }
  public int getMetatileCount()           { return 85; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int[] getPalAddresses()            { return new[] {0x118BD}; }
  public int[] getPatternTableFirstHalfAddr() { return new[] {0x12000, 0x12800, 0x13000, 0x13800}; }
  public int[] getPatternTableSecondHalfAddr() { return new[] {0x3800}; }
}