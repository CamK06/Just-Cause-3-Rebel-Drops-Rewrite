using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace JustCauseRebelDrops.Classes
{
    public class CustomWeaponConfig
    {
        public string CategoryName { get; set; }
        public List<Weapon> Weapons { get; set; }

        /// <summary>
        /// Loads a custom weapon config file
        /// </summary>
        /// <param name="FileToLoad">The file to load from</param>
        /// <returns>CustomWeaponConfig</returns>
        public static CustomWeaponConfig LoadFromFile(string FileToLoad)
        {
            if (FileToLoad.ToLower().EndsWith(".json")) return JsonConvert.DeserializeObject<CustomWeaponConfig>(File.ReadAllText(FileToLoad));
            else if (FileToLoad.ToLower().EndsWith(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CustomWeaponConfig));
                FileStream stream = new FileStream(FileToLoad, FileMode.Open);
                CustomWeaponConfig config = (CustomWeaponConfig)serializer.Deserialize(stream);
                stream.Close();
                return config;
            }
            else return new CustomWeaponConfig();
        }
    }
}
