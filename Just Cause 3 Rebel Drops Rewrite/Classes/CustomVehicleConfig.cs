using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JustCauseRebelDrops.Classes
{
    internal class CustomVehicleConfig
    {
        public string CategoryName { get; set; }
        public List<DropVehicle> Vehicles { get; set; }

        /// <summary>
        /// Loads a custom vehicle config file
        /// </summary>
        /// <param name="FileToLoad">The file to load from</param>
        /// <returns>CustomVehicleConfig from json</returns>
        public static CustomVehicleConfig LoadFromFile(string FileToLoad)
        {
            return JsonConvert.DeserializeObject<CustomVehicleConfig>(File.ReadAllText(FileToLoad));
        }
    }
}
