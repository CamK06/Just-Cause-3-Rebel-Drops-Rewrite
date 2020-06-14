using JustCauseRebelDrops.Classes;
using Newtonsoft.Json;
using System.IO;

namespace JustCauseRebelDrops
{
    internal class Util
    {
        /// <summary>
        /// Verifies that all of the mod's files that it depends on are there
        /// </summary>
        public static void VerifyFileStructure()
        {
            if (!Directory.Exists(Globals.ResourceDir)) Directory.CreateDirectory(Globals.ResourceDir);
            if (!File.Exists(Globals.ConfigFile))
            {
                ModConfig config = new ModConfig();
                File.WriteAllText(Globals.ConfigFile, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            if (!File.Exists(Globals.VehicleFile))
            if (!File.Exists(Globals.HitSound)) Main.PlaySound = false;
            if (!File.Exists(Globals.CallSound)) Main.PlaySound = false;
        }
    }
}
