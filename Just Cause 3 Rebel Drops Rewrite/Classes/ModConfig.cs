using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Windows.Forms;

namespace JustCauseRebelDrops.Classes
{
    public class ModConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Keys dropMenu { get; set; } = Keys.L;
        public bool requireShift { get; set; } = true;
        public string planeModel { get; set; } = "lazer";
    }
}
