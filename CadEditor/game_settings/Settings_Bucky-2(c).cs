using CadEditor;
using System;

public static class BuckyUtils 
{ 
    public static GetPalFunc readPalFromBin(string[] fname)
    {
        return (int x)=> { return Utils.readBinFile(fname[x]); };
    }
    
    public static GetVideoChunkFunc getVideoChunk(string[] fname)
    {
       return (int x)=> { return Utils.readVideoBankFromFile(fname[x], 0); };
    }
}

public class Data 
{ 
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x9cc1, 25 , 8*6, 8, 6);   }

  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 2   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 3   , 16); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return BuckyUtils.getVideoChunk(new[] {"chr2(b).bin", "chr2(c).bin"}); }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0x9188, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0x96b8; }
  
  public GetPalFunc           getPalFunc()           { return BuckyUtils.readPalFromBin(new[] {"pal2(b).bin", "pal2(c).bin", "pal2(d).bin"}); }
}