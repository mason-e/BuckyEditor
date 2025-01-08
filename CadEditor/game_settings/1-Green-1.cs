using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x8b10, 9 , 8*6, 8, 6);   }
  
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 1   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 1   , 16); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return Utils.getVideoChunk(new[] {"chr1(a).bin"}); }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x8011, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0x89e1; }
  
  public GetPalFunc           getPalFunc()           { return Utils.readPalFromBin(new[] {"pal1(a).bin"}); }
}