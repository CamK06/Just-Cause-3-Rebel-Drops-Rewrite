using GTA;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JustCauseRebelDrops.Classes
{
    public class Weapon
    {
        public string DisplayName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PickupType Hash { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WeaponCategory Type { get; set; }
    }

    public enum WeaponCategory
    {
        Heavy, Sidearm, Primary
    }
}
