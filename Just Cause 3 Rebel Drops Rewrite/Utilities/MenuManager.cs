using GTA;
using JustCauseRebelDrops.Classes;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCauseRebelDrops.Utilities
{
    internal class MenuManager
    {
        internal static MenuPool MainPool = new MenuPool();

        static UIMenu MainMenu = new UIMenu("Rebel Drops", "Select a drop type");
        static UIMenu VehicleMenu = null;
        static UIMenu WeaponsMenu = null;
        static UIMenu MilitaryMenu = null;
        static UIMenu CivilianMenu = null;
        static UIMenu CivAir = null;
        static UIMenu CivLand = null;
        static UIMenu CivSea = null;
        static UIMenu MilAir = null;
        static UIMenu MilLand = null;
        static UIMenu MilSea = null;
        static List<UIMenuItem> Vehicles = new List<UIMenuItem>();

        /// <summary>
        /// Initialize all of the menus
        /// </summary>
        public static void Init()
        {
            MainPool.Add(MainMenu);
            VehicleMenu = MainPool.AddSubMenu(MainMenu, "Vehicles");
            WeaponsMenu = MainPool.AddSubMenu(MainMenu, "Weapons");
            WeaponsMenu.AddItem(new UIMenuItem("Weapon drops are currently not implemented."));

            CivilianMenu = MainPool.AddSubMenu(VehicleMenu, "Civilian Vehicles");
            MilitaryMenu = MainPool.AddSubMenu(VehicleMenu, "Military Vehicles");

            CivAir = MainPool.AddSubMenu(CivilianMenu, "Air");
            CivLand = MainPool.AddSubMenu(CivilianMenu, "Land");
            CivSea = MainPool.AddSubMenu(CivilianMenu, "Sea");
            MilAir = MainPool.AddSubMenu(MilitaryMenu, "Air");
            MilLand = MainPool.AddSubMenu(MilitaryMenu, "Land");
            MilSea = MainPool.AddSubMenu(MilitaryMenu, "Sea");

            // Civilian vehicles
            foreach (DropVehicle veh in Main.VehConfig.CivilianVehicles)
            {
                switch (veh.Type) 
                {
                    case VehicleType.Heli:
                    case VehicleType.Plane:
                        var VehicleItem = new UIMenuItem(veh.DisplayName);
                        VehicleItem.Activated += ItemSelect;
                        CivAir.AddItem(VehicleItem);
                        break;

                    case VehicleType.Land:
                        var LandVehicleItem = new UIMenuItem(veh.DisplayName);
                        LandVehicleItem.Activated += ItemSelect;
                        CivLand.AddItem(LandVehicleItem);
                        break;

                    case VehicleType.Sea:
                        var SeaVehicleItem = new UIMenuItem(veh.DisplayName);
                        SeaVehicleItem.Activated += ItemSelect;
                        CivSea.AddItem(SeaVehicleItem);
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
                        var VehicleItem = new UIMenuItem(veh.DisplayName);
                        VehicleItem.Activated += ItemSelect;
                        MilAir.AddItem(VehicleItem);
                        break;

                    case VehicleType.Land:
                        var LandVehicleItem = new UIMenuItem(veh.DisplayName);
                        LandVehicleItem.Activated += ItemSelect;
                        MilLand.AddItem(LandVehicleItem);
                        break;

                    case VehicleType.Sea:
                        var SeaVehicleItem = new UIMenuItem(veh.DisplayName);
                        SeaVehicleItem.Activated += ItemSelect;
                        MilSea.AddItem(SeaVehicleItem);
                        break;
                }
            }

            MainPool.RefreshIndex();
        }

        private static void ItemSelect(UIMenu Menu, UIMenuItem Item)
        {
            DropVehicle VehicleToDrop = null;
            VehicleToDrop = Main.VehConfig.CivilianVehicles.FirstOrDefault(x => x.DisplayName.ToLower() == Item.Text.ToLower());
            if (VehicleToDrop == null) VehicleToDrop = Main.VehConfig.MilitaryVehicles.FirstOrDefault(x => x.DisplayName.ToLower() == Item.Text.ToLower());
            if (VehicleToDrop == null) VehicleToDrop = Main.CustomVehicleConfigs.FirstOrDefault(x => x.Vehicles.FirstOrDefault(y => y.DisplayName.ToLower() == Item.Text.ToLower()) != null).Vehicles.FirstOrDefault(x => x.DisplayName.ToLower() == Item.Text.ToLower()); // Basically check for a custom config that has the vehicle
            if (VehicleToDrop == null) return;

            MainPool.CloseAllMenus();
            Main.CallVehicleDrop(VehicleToDrop.ModelName);
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
