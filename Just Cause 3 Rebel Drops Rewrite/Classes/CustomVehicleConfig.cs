using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace JustCauseRebelDrops.Classes
{
    public class CustomVehicleConfig
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
            if (FileToLoad.ToLower().EndsWith(".json")) return JsonConvert.DeserializeObject<CustomVehicleConfig>(File.ReadAllText(FileToLoad));
            else if (FileToLoad.ToLower().EndsWith(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CustomVehicleConfig));
                FileStream stream = new FileStream(FileToLoad, FileMode.Open);
                CustomVehicleConfig config = (CustomVehicleConfig)serializer.Deserialize(stream);
                stream.Close();
                return config;
            }
            else return new CustomVehicleConfig();
        }
    }
}
