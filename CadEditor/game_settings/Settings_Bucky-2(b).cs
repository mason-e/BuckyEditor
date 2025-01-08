using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x9a89, 1 , 8*71, 8, 71);   }
  
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 2   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 2   , 16); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return Utils.getVideoChunk(new[] {"chr2(a).bin", "chr2(b).bin"}); }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x9188, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0x96b8; }
  
  public GetPalFunc           getPalFunc()           { return Utils.readPalFromBin(new[] {"pal2(b).bin", "pal2(c).bin"}); }
}