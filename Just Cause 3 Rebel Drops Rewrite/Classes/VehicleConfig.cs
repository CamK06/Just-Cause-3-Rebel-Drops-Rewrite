using System.Collections.Generic;

namespace JustCauseRebelDrops.Classes
{
    internal class VehicleConfig
    {
        public static List<Vehicle> CivilianVehicles { get; set; } = new List<Vehicle>();
        public static List<Vehicle> MilitaryVehicles { get; set; } = new List<Vehicle>();
    }

    internal enum VehicleCategory
    {
        Civilian, Military
    }
}
