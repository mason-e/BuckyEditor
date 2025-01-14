using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x8cc0, 6 , 8*6, 8, 6);   }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x8011, 1  , 0x1000);  }
  public int getBlocksCount()           { return 85; }
  public int getPalBytesAddr()          { return 0x89e1; }
  public int getPalAddress()            { return 0x117E5; }
  public int[] getPatternTableAddresses()   { return new[] {0x0, 0x0800}; }
}