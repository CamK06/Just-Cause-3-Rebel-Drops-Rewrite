using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JustCauseRebelDrops.Classes
{
    internal class VehicleConfig
    {
        public List<Vehicle> CivilianVehicles { get; set; } = new List<Vehicle>();
        public List<Vehicle> MilitaryVehicles { get; set; } = new List<Vehicle>();

        /// <summary>
        /// Load the vehicle config
        /// </summary>
        /// <returns>VehicleConfig from json</returns>
        public static VehicleConfig Load()
        {
            return JsonConvert.DeserializeObject<VehicleConfig>(File.ReadAllText(Globals.VehicleFile));
        }
    }
}
