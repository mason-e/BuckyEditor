using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CSScriptLibrary;

namespace CadEditor
{
    public delegate byte[] GetVideoChunkFunc(int videoPageId);
    public delegate void SetVideoChunkFunc(int videoPageId, byte[] videoChunk);

    public delegate int GetBlocksAddrFunc(int blockId);
    public delegate int GetBlocksCountFunc(int blockId);

    public delegate BigBlock[] GetBigBlocksFunc(int bigBlockId);
    public delegate void SetBigBlocksFunc(int bigTileIndex, BigBlock[] bigBlocks);
    public delegate int GetBigBlocksAddrFunc(int bigBlockId);
    public delegate int GetBigBlocksCountFunc(int hierLevel, int bigBlockId);

    public delegate byte[] GetPalFunc(int palId);

    public delegate void RenderToMainScreenFunc(Graphics g, int curScale, int scrNo);

    public delegate int ConvertScreenTileFunc(int val);
    public delegate int GetBigTileNoFromScreenFunc(int[] screenData, int index);
    public delegate void SetBigTileToScreenFunc(int[] screenData, int index, int value);

    public delegate Screen[] LoadScreensFunc();
    public delegate void SaveScreensFunc(Screen[] screens);

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

            palOffset = callFromScript(asm, data, "*.getPalOffset", new OffsetRec(0, 1, 0));
            videoOffset = callFromScript(asm, data, "*.getVideoOffset", new OffsetRec(0, 1, 0));
            blocksOffset = callFromScript(asm, data, "*.getBlocksOffset", new OffsetRec(0, 1, 0));
            screensOffset[0] = callFromScript(asm, data, "*.getScreensOffset", new OffsetRec(0, 1, 0, -1, -1));

            bigBlocksHierarchyCount = callFromScript<int>(asm, data, "*.getBigBlocksHierarchyCount", 1);

            bigBlocksCounts = new int[bigBlocksHierarchyCount];
            for (int hierLevel = 0; hierLevel < bigBlocksHierarchyCount; hierLevel++)
            {
                bigBlocksCounts[hierLevel] = callFromScript(asm, data, "*.getBigBlocksCountHierarchy", 256, hierLevel);
            }
            bigBlocksCounts[0] = callFromScript(asm, data, "*.getBigBlocksCount", bigBlocksCounts[0]);
            getBigBlocksCountFunc = callFromScript<GetBigBlocksCountFunc>(asm, data, "*.getBigBlocksCountFunc");

            getVideoChunkFunc = callFromScript<GetVideoChunkFunc>(asm, data, "*.getVideoChunkFunc");
            setVideoChunkFunc = callFromScript<SetVideoChunkFunc>(asm, data, "*.setVideoChunkFunc");

            getBigBlocksFuncs = callFromScript<GetBigBlocksFunc[]>(asm, data, "*.getBigBlocksFuncs", new GetBigBlocksFunc[1]);
            setBigBlocksFuncs = callFromScript<SetBigBlocksFunc[]>(asm, data, "*.setBigBlocksFuncs", new SetBigBlocksFunc[1]);
            getBigBlocksAddrFuncs = callFromScript<GetBigBlocksAddrFunc[]>(asm, data, "*.getBigBlocksAddrFuncs", new GetBigBlocksAddrFunc[1]);

            getBlocksAddrFunc = callFromScript<GetBlocksAddrFunc>(asm, data, "*.getBlocksAddrFunc");
            getPalFunc = callFromScript<GetPalFunc>(asm, data, "*.getPalFunc");
            convertScreenTileFunc = callFromScript<ConvertScreenTileFunc>(asm, data, "*.getConvertScreenTileFunc");
            backConvertScreenTileFunc = callFromScript<ConvertScreenTileFunc>(asm, data, "*.getBackConvertScreenTileFunc");
            getBigTileNoFromScreenFunc = callFromScript<GetBigTileNoFromScreenFunc>(asm, data, "*.getBigTileNoFromScreenFunc", Utils.getBigTileNoFromScreen);
            setBigTileToScreenFunc = callFromScript<SetBigTileToScreenFunc>(asm, data, "*.setBigTileToScreenFunc", Utils.setBigTileToScreen);

            renderToMainScreenFunc = callFromScript<RenderToMainScreenFunc>(asm, data, "*.getRenderToMainScreenFunc");

            blocksCount = callFromScript(asm, data, "*.getBlocksCount", 256);
            getBlocksCountFunc = callFromScript<GetBlocksCountFunc>(asm, data, "*.getBlocksCountFunc");

            loadScreensFunc = callFromScript<LoadScreensFunc>(asm, data, "*.loadScreensFunc");
            saveScreensFunc = callFromScript<SaveScreensFunc>(asm, data, "*.saveScreensFunc");

            blocksPicturesWidth = callFromScript(asm, data, "getPictureBlocksWidth", 32);

            palBytesAddr = callFromScript(asm, data, "*.getPalBytesAddr", -1);
            getPalBytesAddrFunc = callFromScript<GetPalBytesAddrFunc>(asm, data, "*.getPalBytesAddrFunc");

            defaultScale = callFromScript(asm, data, "*.getDefaultScale", -1.0f);

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

        public static byte[] getVideoChunk(int videoPageId)
        {
            return (getVideoChunkFunc ?? (_ => null))(videoPageId);
        }

        public static void setVideoChunk(int videoPageId, byte[] videoChunk)
        {
            setVideoChunkFunc(videoPageId, videoChunk);
        }

        public static BigBlock[] getBigBlocksRecursive(int hierarchyLevel, int bigBlockId)
        {
            return (getBigBlocksFuncs[hierarchyLevel] ?? (_ => null))(bigBlockId);
        }

        public static ObjRec[] getBlocks(int bigBlockId)
        {
            return Utils.getBlocksFromTiles16Pal1(bigBlockId);
        }

        public static void setBlocks(int bIndex, ObjRec[] blocks)
        {
            Utils.setBlocksFromTiles16Pal1(bIndex, blocks);
        }

        public static byte[] getPal(int palId)
        {
            return (getPalFunc ?? (_ => null))(palId);
        }

        public static int convertScreenTile(int tile)
        {
            return (convertScreenTileFunc ?? (v => v))(tile);
        }

        public static int backConvertScreenTile(int tile)
        {
            return (backConvertScreenTileFunc ?? (v => v))(tile);
        }

        public static int getBigTileNoFromScreen(int[] screenData, int index)
        {
            return getBigTileNoFromScreenFunc(screenData, index);
        }

        public static void setBigTileToScreen(int[] screenData, int index, int value)
        {
            setBigTileToScreenFunc(screenData, index, value);
        }

        public static Screen[] loadScreens()
        {
            if (loadScreensFunc != null)
            {
                return loadScreensFunc();
            }
            else
            {
                return Utils.loadScreensDiffSize();
            }
        }

        public static void saveScreens(Screen[] screens)
        {
            if (saveScreensFunc != null)
            {
                saveScreensFunc(screens);
            }
            else
            {
                Utils.saveScreensDiffSize(screens);
            }
        }

        public static void renderToMainScreen(Graphics g, int scale, int scrNo)
        {
            renderToMainScreenFunc?.Invoke(g, scale, scrNo);
        }

        public static int getBigBlocksCount(int hierarchyLevel, int bigBlockId)
        {
            return getBigBlocksCountFunc?.Invoke(hierarchyLevel, bigBlockId) ?? bigBlocksCounts[hierarchyLevel];
        }

        public static int getBlocksCount(int blockId)
        {
            return getBlocksCountFunc?.Invoke(blockId) ?? blocksCount;
        }

        public static string[] getBlockTypeNames()
        {
            return defaultBlockTypeNames;
        }

        public static int getBlocksPicturesWidth()
        {
            return blocksPicturesWidth;
        }

        public static int getPalBytesAddr(int blockId)
        {
            return getPalBytesAddrFunc?.Invoke(blockId) ?? palBytesAddr;
        }

        public static float getDefaultScale()
        {
            return defaultScale;
        }

        //------------------------------------------------------------

        public static int getTilesAddr(int id)
        {
            var getAddrFunc = ConfigScript.getBlocksAddrFunc;
            return getAddrFunc?.Invoke(id) ?? getTilesAddrDefault(id);

        }

        private static int getTilesAddrDefault(int id)
        {
            return ConfigScript.blocksOffset.beginAddr + ConfigScript.blocksOffset.recSize * id;
        }

        public static int getbigBlocksHierarchyCount()
        {
            return bigBlocksHierarchyCount;
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

        public static OffsetRec palOffset;
        public static OffsetRec videoOffset;
        public static OffsetRec blocksOffset;
        public static OffsetRec[] screensOffset;

        public static GetVideoChunkFunc getVideoChunkFunc;
        public static SetVideoChunkFunc setVideoChunkFunc;

        public static int bigBlocksHierarchyCount;
        public static int[] bigBlocksCounts;
        public static GetBigBlocksFunc[] getBigBlocksFuncs;
        public static SetBigBlocksFunc[] setBigBlocksFuncs;
        public static GetBigBlocksAddrFunc[] getBigBlocksAddrFuncs;
        public static GetBigBlocksCountFunc getBigBlocksCountFunc;

        public static int blocksCount;
        public static GetBlocksAddrFunc getBlocksAddrFunc;
        public static GetBlocksCountFunc getBlocksCountFunc;

        public static GetPalFunc getPalFunc;

        public static RenderToMainScreenFunc renderToMainScreenFunc;

        public static ConvertScreenTileFunc convertScreenTileFunc;
        public static ConvertScreenTileFunc backConvertScreenTileFunc;

        public static GetBigTileNoFromScreenFunc getBigTileNoFromScreenFunc;
        public static SetBigTileToScreenFunc setBigTileToScreenFunc;

        public static LoadScreensFunc loadScreensFunc;
        public static SaveScreensFunc saveScreensFunc;

        public static float defaultScale;

        public static int blocksPicturesWidth;

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
