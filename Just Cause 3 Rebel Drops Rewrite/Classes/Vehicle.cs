namespace JustCauseRebelDrops.Classes
{
    internal class Vehicle
    {
        public string modelName { get; set; }
        public string displayName { get; set; }
        public VehicleType type { get; set; }
    }

    internal enum VehicleType
    {
        Land, Plane, Heli, Sea
    }
}
