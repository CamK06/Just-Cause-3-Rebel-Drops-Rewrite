using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Windows.Forms;

namespace JustCauseRebelDrops.Classes
{
    public class ModConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys DropMenu { get; set; } = Keys.L;
        public bool RequiresShift { get; set; } = true;
        public string PlaneModel { get; set; } = "lazer";
        public int VehicleCost { get; set; } = 0;

        /// <summary>
        /// Load the modconfig
        /// </summary>
        /// <returns>ModConfig from config file</returns>
        public static ModConfig Load()
        {
            return JsonConvert.DeserializeObject<ModConfig>(File.ReadAllText(Globals.ConfigFile));
        }
    }
}
