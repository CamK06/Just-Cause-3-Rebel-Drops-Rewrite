using System.Collections.Generic;

namespace JustCauseRebelDrops.Classes
{
    internal class VehicleConfig
    {
        public List<Vehicle> CivilianVehicles { get; set; } = new List<Vehicle>();
        public List<Vehicle> MilitaryVehicles { get; set; } = new List<Vehicle>();
    }

    internal enum VehicleCategory
    {
        Civilian, Military
    }
}
