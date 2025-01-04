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
  public OffsetRec getScreensOffset()  { return new OffsetRec(0xa86f, 28 , 8*6, 8, 6);   }
  
  public OffsetRec getVideoOffset()     { return new OffsetRec(0x0 , 4   , 0x1000);  }
  public OffsetRec getPalOffset  ()     { return new OffsetRec(0x0 , 3   , 16); }
  public GetVideoChunkFunc    getVideoChunkFunc()    { return BuckyUtils.getVideoChunk(new[] {"chr3(a).bin", "chr3(aa).bin", "chr3(b).bin", "chr3(c).bin"}); }
  public SetVideoChunkFunc    setVideoChunkFunc()    { return null; }
  
  public OffsetRec getBlocksOffset()    { return new OffsetRec(0xa181, 1  , 0x1000);  }
  public int getBlocksCount()           { return 244; }
  public int getBigBlocksCount()        { return 244; }
  public int getPalBytesAddr()          { return 0xa7c1; }
  
  public GetPalFunc           getPalFunc()           { return BuckyUtils.readPalFromBin(new[] {"pal3(a).bin", "pal3(b).bin", "pal3(c).bin"}); }
}