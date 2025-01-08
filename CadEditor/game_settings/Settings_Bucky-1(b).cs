using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x8df0, 15 , 8*6, 8, 6);   }
    
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 2   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 2   , 16); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return Utils.getVideoChunk(new[] {"chr1(b).bin", "chr1(c).bin"}); }
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x8011, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0x89e1; }
  
  public GetPalFunc           getPalFunc()           { return Utils.readPalFromBin(new[] {"pal1(c).bin", "pal1(d).bin"}); }
}