using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xcb98, 10 , 8*6, 8, 6);   }
      
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 1   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 2   , 16); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return Utils.getVideoChunk(new[] {"chr4(a).bin"}); }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xc011, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0xca21; }
  
  public GetPalFunc           getPalFunc()           { return Utils.readPalFromBin(new[] {"pal4(a).bin", "pal4(b).bin"}); }
}