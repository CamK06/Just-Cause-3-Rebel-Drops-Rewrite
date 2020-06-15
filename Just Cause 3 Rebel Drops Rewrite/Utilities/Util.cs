using JustCauseRebelDrops.Classes;
using Newtonsoft.Json;
using System.IO;

namespace JustCauseRebelDrops
{
    internal class Util
    {
        /// <summary>
        /// Verifies that all of the mod's files are there
        /// </summary>
        public static void VerifyFileStructure()
        {
            if (!Directory.Exists(Globals.ResourceDir)) Directory.CreateDirectory(Globals.ResourceDir);
            if (!Directory.Exists(Globals.CustomVehicleDir)) Directory.CreateDirectory(Globals.CustomVehicleDir);
            if (!File.Exists(Globals.ConfigFile))
            {
                ModConfig config = new ModConfig();
                File.WriteAllText(Globals.ConfigFile, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            if (!File.Exists(Globals.VehicleFile))
            {
                VehicleConfig vehicles = new VehicleConfig();
                File.WriteAllText(Globals.VehicleFile, JsonConvert.SerializeObject(vehicles, Formatting.Indented));
            }
            if (!File.Exists(Globals.WeaponFile))
            {
                WeaponConfig weapons = new WeaponConfig();
                File.WriteAllText(Globals.WeaponFile, JsonConvert.SerializeObject(weapons, Formatting.Indented));
            }
            if (!File.Exists(Globals.HitSound)) Main.PlaySound = false;
            if (!File.Exists(Globals.CallSound)) Main.PlaySound = false;
        }
    }
}
