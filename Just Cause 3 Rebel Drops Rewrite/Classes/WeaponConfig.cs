using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JustCauseRebelDrops.Classes
{
    internal class WeaponConfig
    {
        public List<Weapon> HeavyWeapons { get; set; } = new List<Weapon>();
        public List<Weapon> SideWeapons { get; set; } = new List<Weapon>();
        public List<Weapon> PrimaryWeapons { get; set; } = new List<Weapon>();

        /// <summary>
        /// Load the vehicle config
        /// </summary>
        /// <returns>VehicleConfig from json</returns>
        public static WeaponConfig Load()
        {
            return JsonConvert.DeserializeObject<WeaponConfig>(File.ReadAllText(Globals.WeaponFile));
        }
    }
}
