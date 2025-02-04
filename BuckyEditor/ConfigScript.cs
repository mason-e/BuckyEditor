﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CSScriptLibrary;

namespace BuckyEditor
{
    public delegate byte[] GetPalFunc(int palId);

    public delegate int GetPalBytesAddrFunc(int blockId);

    public class ConfigScript
    {
        static ConfigScript()
        {
            //add pathes for including scripts
            var globalSettings = CSScript.GlobalSettings;
            globalSettings.AddSearchDir("./game_settings");
        }
        public static void LoadGlobalsFromFile(string fileName)
        {
            try
            {
                var asm = new AsmHelper(CSScript.Load(fileName));
                object data = asm.CreateObject("Config");
                romName = callFromScript(asm, data, "*.getFileName", "");
                cfgName = callFromScript(asm, data, "*.getConfigName", "");
            }
            catch (Exception)
            {
            }
        }

        public static void LoadFromFile(string fileName)
        {
            programStartDirectory = AppDomain.CurrentDomain.BaseDirectory + "/";
            configDirectory = Path.GetDirectoryName(fileName) + "/";

            var asm = new AsmHelper(CSScript.LoadCode(File.ReadAllText(fileName)));
            object data = asm.CreateObject("Data");

            metatileAddress = callFromScript(asm, data, "*.getMetatileAddress", 0);
            levelStartAddress = callFromScript(asm, data, "*.getLevelStartAddr", 0);
            screenCount = callFromScript(asm, data, "*.getScreenCount", 1);
            screenHeight = callFromScript(asm, data, "*.getScreenHeight", 6);
            screenSize = screenHeight * 8; // all screens are 8 metatiles wide

            paletteAddresses = callFromScript(asm, data, "*.getPalAddresses", new int[] {0});
            patternTableFirstHalfAddr = callFromScript(asm, data, "*.getPatternTableFirstHalfAddr", new int[] {0});
            patternTableSecondHalfAddr = callFromScript(asm, data, "*.getPatternTableSecondHalfAddr", new int[] {0});
            patternTableSize = Math.Max(patternTableFirstHalfAddr.Length, patternTableSecondHalfAddr.Length);

            metatileCount = callFromScript(asm, data, "*.getMetatileCount", 256);

            palBytesAddr = callFromScript(asm, data, "*.getPalBytesAddr", -1);
        }

        public static ObjRec[] getBlocks()
        {
            return Utils.getBlocksFromTiles16Pal1();
        }

        public static void setBlocks(ObjRec[] blocks)
        {
            Utils.setBlocksFromTiles16Pal1(blocks);
        }

        public static Screen[] loadScreens()
        {
            return Utils.loadScreensDiffSize();
        }

        public static void saveScreens(Screen[] screens)
        {
            Utils.saveScreensDiffSize(screens);
        }

        public static int getPalBytesAddr()
        {
            return palBytesAddr;
        }

        //------------------------------------------------------------

        public static int getMetatileAddress()
        {
            return metatileAddress;

        }

        public static T callFromScript<T>(AsmHelper script, object data, string funcName, T defaultValue = default(T), params object[] funcParams)
        {
            try
            {
                return (T)script.InvokeInst(data, funcName, funcParams);
            }
            catch (Exception) //all exception catch...
            {
                return defaultValue;
            }
        }

        private static string programStartDirectory;
        private static string configDirectory;

        public static string ConfigDirectory { get { return configDirectory; } }

        public static int metatileAddress;

        public static int levelStartAddress;

        public static int screenCount;

        public static int screenHeight;

        public static int screenSize;

        public static int metatileCount;

        public static int[] patternTableFirstHalfAddr;

        public static int[] patternTableSecondHalfAddr;

        public static int patternTableSize;
        
        public static int[] paletteAddresses;

        public static int palBytesAddr;

        //global editor settings
        public static string romName;
        public static string cfgName;
        public static Color[] nesColors;
    }
}
