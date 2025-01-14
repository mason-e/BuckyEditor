using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CSScriptLibrary;

namespace CadEditor
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
                nesColors = callFromScript<Color[]>(asm, data, "*.getNesColors", null);
            }
            catch (Exception)
            {
            }
        }

        public static void loadPluginWithSilentCatch(Action action)
        {
            try
            {
                action();
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

            screensOffset = new OffsetRec[1];

            blocksOffset = callFromScript(asm, data, "*.getBlocksOffset", new OffsetRec(0, 1, 0));
            screensOffset[0] = callFromScript(asm, data, "*.getScreensOffset", new OffsetRec(0, 1, 0, -1, -1));

            paletteAddress = callFromScript(asm, data, "*.getPalAddress", 0);
            patternTableAddresses = callFromScript(asm, data, "*.getPatternTableAddresses", new int[1]);

            blocksCount = callFromScript(asm, data, "*.getBlocksCount", 256);

            palBytesAddr = callFromScript(asm, data, "*.getPalBytesAddr", -1);

            loadAllPlugins(asm, data);

            ConfigScript.videoNes.updateColorsFromConfig();
        }

        private static void loadAllPlugins(AsmHelper asm, object data)
        {
            cleanPlugins();
            loadGlobalPlugins();
            loadPluginsFromCurrentConfig(asm, data);
        }

        private static void cleanPlugins()
        {
            plugins.Clear();
            videoNes = null;
        }

        private static void loadGlobalPlugins()
        {
            //auto load video plugins
            loadPluginWithSilentCatch(() => videoNes = PluginLoader.loadPlugin<IVideoPluginNes>("PluginVideoNes.dll"));
        }

        private static void loadPluginsFromCurrentConfig(AsmHelper asm, object data)
        {
            string[] pluginNames = callFromScript(asm, data, "getPluginNames", new string[0]);
            foreach (var pluginName in pluginNames)
            {
                var p = PluginLoader.loadPlugin<IPlugin>(pluginName);
                if (p != null)
                {
                    p.loadFromConfig(asm, data);
                    plugins.Add(p);
                }
            }
            plugins.Reverse();
        }

        public static ObjRec[] getBlocks(int bigBlockId)
        {
            return Utils.getBlocksFromTiles16Pal1(bigBlockId);
        }

        public static void setBlocks(int bIndex, ObjRec[] blocks)
        {
            Utils.setBlocksFromTiles16Pal1(bIndex, blocks);
        }

        public static Screen[] loadScreens()
        {
            return Utils.loadScreensDiffSize();
        }

        public static void saveScreens(Screen[] screens)
        {
            Utils.saveScreensDiffSize(screens);
        }

        public static int getBlocksCount()
        {
            return blocksCount;
        }

        public static string[] getBlockTypeNames()
        {
            return defaultBlockTypeNames;
        }

        public static int getPalBytesAddr()
        {
            return palBytesAddr;
        }

        //------------------------------------------------------------

        public static int getTilesAddr(int id)
        {
            return ConfigScript.blocksOffset.beginAddr + ConfigScript.blocksOffset.recSize * id;

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

        public static string ProgramDirectory { get { return programStartDirectory; } }
        public static string ConfigDirectory { get { return configDirectory; } }

        public static OffsetRec blocksOffset;
        public static OffsetRec[] screensOffset;

        public static int blocksCount;

        public static int[] patternTableAddresses;
        
        public static int paletteAddress;

        public static int palBytesAddr;
        public static GetPalBytesAddrFunc getPalBytesAddrFunc;

        public static string[] defaultBlockTypeNames = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        //global editor settings
        public static string romName;
        public static string cfgName;
        public static Color[] nesColors;

        public static List<IPlugin> plugins = new List<IPlugin>();
        public static IVideoPluginNes videoNes;
    }
}
