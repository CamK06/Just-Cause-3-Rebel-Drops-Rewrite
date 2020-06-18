using GTA.Math;
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
                vehicles.CivilianVehicles.AddRange(Globals.DefaultAir);
                vehicles.CivilianVehicles.AddRange(Globals.DefaultLand);
                vehicles.CivilianVehicles.AddRange(Globals.DefaultSea);
                vehicles.MilitaryVehicles.AddRange(Globals.DefaultMilAir);
                vehicles.MilitaryVehicles.AddRange(Globals.DefaultMilLand);
                vehicles.MilitaryVehicles.AddRange(Globals.DefaultMilSea);
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

        /// <summary>
        /// Used for the cargo plane positioning. I don't really understand how this works, only how to use it
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
        {
            Vector3 P = x * Vector3.Normalize(B - A) + A;
            return P;
        }
    }
}
