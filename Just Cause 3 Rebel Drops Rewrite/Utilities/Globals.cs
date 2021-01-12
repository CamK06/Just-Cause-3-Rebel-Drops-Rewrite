using GTA;
using System.Collections.Generic;

namespace JustCauseRebelDrops
{
    /// <summary>
    /// All of the commonly used objects, mostly directories though
    /// </summary>
    internal class Globals
    {
        internal static string ResourceDir = "scripts\\JustCauseRebelDrops";
        internal static string CustomVehicleDir = ResourceDir + "\\CustomVehicles";
        internal static string VehicleFile = ResourceDir + "\\vehicles.json";
        internal static string WeaponFile = ResourceDir + "\\weapons.json";
        internal static string ConfigFile = ResourceDir + "\\config.json";
        internal static string CallSound = ResourceDir + "\\Audio\\call.mp3";
        internal static string HitSound = ResourceDir + "\\Audio\\groundhit.mp3";

        internal static Model ContainerModel = new Model("prop_contr_03b_ld");

        internal static List<JustCauseRebelDrops.Classes.DropVehicle> DefaultAir = new List<JustCauseRebelDrops.Classes.DropVehicle>()
        {
            // Civilian jets
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Mallard",
                ModelName = "stunt",
                Type = Classes.VehicleType.Plane
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Luxor",
                ModelName = "luxor",
                Type = Classes.VehicleType.Plane
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Nimbus",
                ModelName = "nimbus",
                Type = Classes.VehicleType.Plane
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Jet",
                ModelName = "jet",
                Type = Classes.VehicleType.Plane
            },

            // Civilian helis
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Frogger",
                ModelName = "frogger",
                Type = Classes.VehicleType.Heli
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Swift",
                ModelName = "swift",
                Type = Classes.VehicleType.Heli
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Havok",
                ModelName = "havok",
                Type = Classes.VehicleType.Heli
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Maverick",
                ModelName = "maverick",
                Type = Classes.VehicleType.Heli
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Skylift",
                ModelName = "skylift",
                Type = Classes.VehicleType.Heli
            },
        };

        internal static List<JustCauseRebelDrops.Classes.DropVehicle> DefaultLand = new List<JustCauseRebelDrops.Classes.DropVehicle>()
        {
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Faggio",
                ModelName = "faggio",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Burrito",
                ModelName = "burrito",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Bison",
                ModelName = "bison",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Blista",
                ModelName = "blista",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Ingot",
                ModelName = "ingot",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Adder",
                ModelName = "adder",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Entity XF",
                ModelName = "entityxf",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Bus",
                ModelName = "bus",
                Type = Classes.VehicleType.Land
            },
        };

        internal static List<JustCauseRebelDrops.Classes.DropVehicle> DefaultSea = new List<JustCauseRebelDrops.Classes.DropVehicle>()
        {
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Seashark",
                ModelName = "seashark",
                Type = Classes.VehicleType.Sea
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Dinghy",
                ModelName = "dinghy",
                Type = Classes.VehicleType.Sea
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Jetmax",
                ModelName = "jetmax",
                Type = Classes.VehicleType.Sea
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Marquis",
                ModelName = "marquis",
                Type = Classes.VehicleType.Sea
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Speeder",
                ModelName = "speeder",
                Type = Classes.VehicleType.Sea
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Tug",
                ModelName = "tug",
                Type = Classes.VehicleType.Sea
            }
        };

        internal static List<JustCauseRebelDrops.Classes.DropVehicle> DefaultMilAir = new List<JustCauseRebelDrops.Classes.DropVehicle>()
        {
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Lazer",
                ModelName = "lazer",
                Type = Classes.VehicleType.Plane
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Titan",
                ModelName = "titan",
                Type = Classes.VehicleType.Plane
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Hydra",
                ModelName = "hydra",
                Type = Classes.VehicleType.Plane
            },

            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Cargobob",
                ModelName = "cargobob",
                Type = Classes.VehicleType.Heli
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Buzzard",
                ModelName = "buzzard",
                Type = Classes.VehicleType.Heli
            },
        };

        internal static List<JustCauseRebelDrops.Classes.DropVehicle> DefaultMilLand = new List<JustCauseRebelDrops.Classes.DropVehicle>()
        {
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Rhino",
                ModelName = "rhino",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "APC",
                ModelName = "apc",
                Type = Classes.VehicleType.Land
            },
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Insurgent",
                ModelName = "insurgent",
                Type = Classes.VehicleType.Land
            }
        };

        internal static List<JustCauseRebelDrops.Classes.DropVehicle> DefaultMilSea = new List<JustCauseRebelDrops.Classes.DropVehicle>()
        {
            new JustCauseRebelDrops.Classes.DropVehicle()
            {
                DisplayName = "Kraken",
                ModelName = "submersible2",
                Type = Classes.VehicleType.Sea
            }
        };

    }
}
