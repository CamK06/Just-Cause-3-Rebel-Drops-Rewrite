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
        static UIMenu Air = null;
        static UIMenu LandMenu = null;
        static UIMenu SeaMenu = null;

        /// <summary>
        /// Initialize all of the menus
        /// </summary>
        public static void Init()
        {
            MainPool.Add(MainMenu);
            VehicleMenu = MainPool.AddSubMenu(MainMenu, "Vehicles");
            WeaponsMenu = MainPool.AddSubMenu(MainMenu, "Weapons");

            Air = MainPool.AddSubMenu(VehicleMenu, "Air");
            LandMenu = MainPool.AddSubMenu(VehicleMenu, "Land");
            SeaMenu = MainPool.AddSubMenu(VehicleMenu, "Sea");

            // Civilian vehicles
            foreach (DropVehicle veh in Main.VehConfig.CivilianVehicles)
            {
                switch (veh.Type) 
                {
                    case VehicleType.Heli:
                    case VehicleType.Plane:
                        Air.AddItem(new UIMenuItem(veh.DisplayName));
                        break;

                    case VehicleType.Land:
                        LandMenu.AddItem(new UIMenuItem(veh.DisplayName));
                        break;

                    case VehicleType.Sea:
                        SeaMenu.AddItem(new UIMenuItem(veh.DisplayName));
                        break;
                }
            }

            // Military vehicles
            foreach (DropVehicle veh in Main.VehConfig.MilitaryVehicles)
            {
                switch (veh.Type)
                {

                }
            }

            MainPool.RefreshIndex();
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
