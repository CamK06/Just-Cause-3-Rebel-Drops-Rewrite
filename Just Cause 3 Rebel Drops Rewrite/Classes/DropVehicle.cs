using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JustCauseRebelDrops.Classes
{
    public class DropVehicle
    {
        public string ModelName { get; set; }
        public string DisplayName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public VehicleType Type { get; set; }
    }

    public enum VehicleType
    {
        Land, Plane, Heli, Sea
    }
}
