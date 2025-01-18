using BuckyEditor;
using System;

// First two screens repeat 3 acts for the robo snakes, and are stored in
// reverse order in memory of how they show in game
public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xa98F, 7 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xa181, 1  , 0x1000);  }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  public int getPalAddress()            { return 0x118BD; }
  public int[] getPatternTableAddresses()   { return new[] {0x12000, 0x3800}; }
}