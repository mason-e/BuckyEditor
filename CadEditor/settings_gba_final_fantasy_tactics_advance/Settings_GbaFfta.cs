using CadEditor;
using System;
using System.Drawing;

public class Data 
{ 
  public GameType getGameType()        { return GameType.Generic; }
  public OffsetRec getScreensOffset()  { return new OffsetRec(0x0, 1 , 0x20*0x40);   }
  public int getScreenWidth()          { return 0x20; }
  public int getScreenHeight()         { return 0x40; }
  public int getWordLen()              { return 2;}
  public bool isLittleEndian()         { return true; }
  public int    getPictureBlocksWidth(){ return 64; }
  public int getBigBlocksCount()       { return 576; }
  public string getBlocksFilename()    { return "settings_gba_final_fantasy_tactics_advance/gba_ffta_1.png"; }
  
  public bool isBigBlockEditorEnabled() { return false; }
  public bool isBlockEditorEnabled()    { return false; }
  public bool isLayoutEditorEnabled()   { return false; }
  public bool isEnemyEditorEnabled()    { return false; }
  public bool isVideoEditorEnabled()    { return false; }
}