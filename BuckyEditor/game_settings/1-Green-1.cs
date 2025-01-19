using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x8b10, 9 , 8*6, 8, 6);   }
  
  public int getMetatileAddress()    { return 0x8011; }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x89e1; }
  public int getPalAddress()            { return 0x117D3; }
  public int[] getPatternTableAddresses()   { return new[] {0x0, 0x0800}; }
}