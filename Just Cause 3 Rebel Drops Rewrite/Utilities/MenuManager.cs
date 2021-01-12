using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GTA;
using GTA.UI;
using LemonUI;
using LemonUI.Menus;

using JustCauseRebelDrops.Classes;
using LemonUI.Elements;
using Screen = GTA.UI.Screen;

namespace JustCauseRebelDrops.Utilities
{
    internal class MenuManager
    {
        internal static ObjectPool MainPool = new ObjectPool();

        static NativeMenu MainMenu = new NativeMenu("Rebel Drops");
        static NativeMenu VehicleMenu = new NativeMenu("Vehicles", "Vehicles");
        static NativeMenu WeaponsMenu = new NativeMenu("Weapons", "Weapons");
        static NativeMenu MilitaryMenu = new NativeMenu("Military Vehicles", "Military");
        static NativeMenu CivilianMenu = new NativeMenu("Civilian Vehicles", "Civilian");
        static NativeMenu CivAir = new NativeMenu("Air", "Air");
        static NativeMenu CivLand = new NativeMenu("Land", "Land");
        static NativeMenu CivSea = new NativeMenu("Sea", "Sea");
        static NativeMenu MilAir = new NativeMenu("Air", "Air");
        static NativeMenu MilLand = new NativeMenu("Land", "Land");
        static NativeMenu MilSea = new NativeMenu("Sea", "Sea");
        static List<DropVehicle> CustomVehicles = new List<DropVehicle>();

        /// <summary>
        /// Initialize all of the menus
        /// </summary>
        public static void Init()
        {
            WeaponsMenu.Add(new NativeItem("Weapons are not implemented yet."));
            CivilianMenu.AddSubMenu(CivAir);
            CivilianMenu.AddSubMenu(CivLand);
            CivilianMenu.AddSubMenu(CivSea);
            MilitaryMenu.AddSubMenu(MilAir);
            MilitaryMenu.AddSubMenu(MilLand);
            MilitaryMenu.AddSubMenu(MilSea);
            VehicleMenu.AddSubMenu(CivilianMenu);
            VehicleMenu.AddSubMenu(MilitaryMenu);
            MainMenu.AddSubMenu(VehicleMenu);
            MainMenu.AddSubMenu(WeaponsMenu);
            
            MainPool.Add(CivAir);
            MainPool.Add(CivLand);
            MainPool.Add(CivSea);
            MainPool.Add(MilAir);
            MainPool.Add(MilLand);
            MainPool.Add(MilSea);
            MainPool.Add(CivilianMenu);
            MainPool.Add(MilitaryMenu);
            MainPool.Add(VehicleMenu);
            MainPool.Add(WeaponsMenu);
            MainPool.Add(MainMenu);

            // Civilian vehicles
            foreach (DropVehicle veh in Main.VehConfig.CivilianVehicles)
            {
                switch (veh.Type) 
                {
                    case VehicleType.Heli:
                    case VehicleType.Plane:
                        var VehicleItem = new NativeItem(veh.DisplayName);
                        VehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                        CivAir.Add(VehicleItem);
                        break;

                    case VehicleType.Land:
                        var LandVehicleItem = new NativeItem(veh.DisplayName);
                        LandVehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                        CivLand.Add(LandVehicleItem);
                        break;

                    case VehicleType.Sea:
                        var SeaVehicleItem = new NativeItem(veh.DisplayName);
                        SeaVehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                        CivSea.Add(SeaVehicleItem);
                        break;
                }
            }

            // Military vehicles
            foreach (DropVehicle veh in Main.VehConfig.MilitaryVehicles)
            {
                switch (veh.Type)
                {
                    case VehicleType.Heli:
                    case VehicleType.Plane:
                        var VehicleItem = new NativeItem(veh.DisplayName);
                        VehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                        MilAir.Add(VehicleItem);
                        break;

                    case VehicleType.Land:
                        var LandVehicleItem = new NativeItem(veh.DisplayName);
                        LandVehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                        MilLand.Add(LandVehicleItem);
                        break;

                    case VehicleType.Sea:
                        var SeaVehicleItem = new NativeItem(veh.DisplayName);
                        SeaVehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                        MilSea.Add(SeaVehicleItem);
                        break;
                }
            }

            // Custom vehicles
            foreach(CustomVehicleConfig CustomVehConfig in Main.CustomVehicleConfigs)
            {
                NativeMenu CustomMenu = new NativeMenu(CustomVehConfig.CategoryName);
                VehicleMenu.AddSubMenu(CustomMenu);

                foreach (DropVehicle veh in CustomVehConfig.Vehicles)
                {
                    switch (veh.Type)
                    {
                        case VehicleType.Heli:
                        case VehicleType.Plane:
                            var VehicleItem = new NativeItem(veh.DisplayName);
                            VehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                            CustomMenu.Add(VehicleItem);
                            break;

                        case VehicleType.Land:
                            var LandVehicleItem = new NativeItem(veh.DisplayName);
                            LandVehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                            CustomMenu.Add(LandVehicleItem);
                            break;

                        case VehicleType.Sea:
                            var SeaVehicleItem = new NativeItem(veh.DisplayName);
                            SeaVehicleItem.Activated += (sender, e) => DropVehicle(veh.ModelName);
                            CustomMenu.Add(SeaVehicleItem);
                            break;
                    }

                    CustomVehicles.Add(veh);
                }
            }
        }

        /// <summary>
        /// Drops a vehicle, the reason we don't just directly call "CallVehicleDrop" is so we can close all menus
        /// </summary>
        private static void DropVehicle(string ModelName)
        {
            MainPool.HideAll();
            Main.CallVehicleDrop(ModelName);
        }

        /// <summary>
        /// Shows the main menu
        /// </summary>
        public static void ShowMenu()
        {
            MainMenu.Visible = !MainMenu.Visible;
        }
    }
}
