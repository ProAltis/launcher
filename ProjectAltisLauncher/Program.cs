﻿using System;
using System.Windows.Forms;
using ProjectAltisLauncher.Enums;
using System.IO;
using System.Threading.Tasks;
using ProjectAltisLauncher.Forms;
using Squirrel;

namespace ProjectAltisLauncher
{
    public static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var filesDir = Path.Combine(appDataPath, "Project Altis");
                if(!Directory.Exists(filesDir))
                    Directory.CreateDirectory(filesDir);
                Directory.SetCurrentDirectory(filesDir);
                Log.Initialize(LogType.Info);
                Log.Info("Loaded altis launcher v" + typeof(Program).Assembly.GetName().Version);
                Log.Info("Current time: " + DateTime.Now.ToLongDateString() + "|" + DateTime.Now.TimeOfDay);
                Log.Info("Working directory: " + Directory.GetCurrentDirectory());
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
                //It'll update in the background while it's running. The update is in effect the next time they restart app.
                MainAsync().Wait();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static async Task MainAsync()
        {
            using (var manager = new UpdateManager("https://judge2020.com/altis"))
            {
                Log.Info("checking for update: " + manager.RootAppDirectory);
                await manager.UpdateApp();
            }
        }
    }
}