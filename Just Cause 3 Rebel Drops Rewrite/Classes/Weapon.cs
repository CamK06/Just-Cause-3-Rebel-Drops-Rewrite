using GTA;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JustCauseRebelDrops.Classes
{
    internal class Weapon
    {
        public string DisplayName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PickupType Hash { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WeaponCategory Type { get; set; }
    }

    internal enum WeaponCategory
    {
        Heavy, Sidearm, Primary
    }
}
