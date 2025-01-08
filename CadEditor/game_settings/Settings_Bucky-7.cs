using CadEditor;
using System;

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xf292, 45 , 8*6, 8, 6);   }

  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 5   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 5   , 16); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return Utils.getVideoChunk(new[] {"chr7(d).bin", "chr7(a).bin", "chr7(b).bin", "chr7(c).bin", "chr7(e).bin"}); }

  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xe3fd, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0xf12d; }
  
  public GetPalFunc           getPalFunc()           { return Utils.readPalFromBin(new[] {"pal7(c).bin", "pal7(a).bin", "pal7(b).bin", "pal7(d).bin", "pal7(e).bin"}); }
}