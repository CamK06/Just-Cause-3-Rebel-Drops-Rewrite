using System;
using System.Collections.Generic;
using System.IO;
using GTA;
using GTA.UI;
using JustCauseRebelDrops.Classes;

namespace JustCauseRebelDrops
{
    public class Main : Script
    {
        internal static bool PlaySound = true;
        internal static ModConfig Config;
        internal static VehicleConfig VehConfig;
        internal static List<CustomVehicleConfig> CustomVehicleConfigs = new List<CustomVehicleConfig>();

        public Main()
        {
            // Old version check
            if (File.Exists("scripts\\JC3RebelDrop.dll") || File.Exists("scripts\\JC3RebelDrop.ini"))
            {
                Notification.Show("~r~Old Just Cause 3 Rebel Drops installation detected. Aborted rewrite loading. Remove JC3RebelDrop.dll and JC3RebelDrop.ini to resolve this issue.");
                return;
            }

            // Setup
            Util.VerifyFileStructure();
            if (PlaySound) AudioManager.InitSounds();
            VehConfig = VehicleConfig.Load();
            foreach (string file in Directory.GetFiles(Globals.CustomVehicleDir, "*.json"))
                CustomVehicleConfigs.Add(CustomVehicleConfig.LoadFromFile(file));
            Config = ModConfig.Load();

            // Event handling
            Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
               
        }
    }
}
