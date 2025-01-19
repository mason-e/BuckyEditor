using BuckyEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x90C0, 1 , 8*14, 8, 14);   }
  
  public int getMetatileAddress()    { return 0x8011; }
  public int getBlocksCount()           { return 157; }
  public int getPalBytesAddr()          { return 0x89e1; }
  public int getPalAddress()            { return 0x1182D; }
  public int[] getPatternTableAddresses()   { return new[] {0x1F000, 0x1000}; }
}