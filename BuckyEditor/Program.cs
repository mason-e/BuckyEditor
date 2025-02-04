﻿using System;
using System.Windows.Forms;
using NDesk.Options;

namespace BuckyEditor
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var globalConfigName = "Config.cs";

                var optionSet = new OptionSet() {
                    { "romname=",      v => OpenFile.fileName = v },
                    { "configname=",  v => OpenFile.configName = v },
                    { "config=",   v => globalConfigName = v },
                };
                var cmdOptions = optionSet.Parse(args);

                ConfigScript.LoadGlobalsFromFile(globalConfigName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
