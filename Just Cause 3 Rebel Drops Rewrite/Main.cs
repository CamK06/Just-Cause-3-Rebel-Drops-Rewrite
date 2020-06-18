using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using JustCauseRebelDrops.Classes;
using JustCauseRebelDrops.Utilities;
using NativeUI;
using Newtonsoft.Json;

namespace JustCauseRebelDrops
{
    public class Main : Script
    {
        internal static bool PlaySound = true;
        internal static ModConfig Config;
        internal static VehicleConfig VehConfig;
        internal static List<CustomVehicleConfig> CustomVehicleConfigs = new List<CustomVehicleConfig>();

        public Main()
        {
            // Old version check
            if (File.Exists("scripts\\JC3RebelDrop.dll") || File.Exists("scripts\\JC3RebelDrop.ini"))
            {
                Notification.Show("~r~Old Just Cause 3 Rebel Drops installation detected. Aborted rewrite loading. Remove JC3RebelDrop.dll and JC3RebelDrop.ini to resolve this issue.");
                return;
            }

            // Setup
            Util.VerifyFileStructure();
            if (PlaySound) AudioManager.InitSounds();
            VehConfig = VehicleConfig.Load();
            foreach (string file in Directory.GetFiles(Globals.CustomVehicleDir, "*.json"))
                CustomVehicleConfigs.Add(CustomVehicleConfig.LoadFromFile(file));
            foreach (string file in Directory.GetFiles(Globals.CustomVehicleDir, "*.xml"))
                CustomVehicleConfigs.Add(CustomVehicleConfig.LoadFromFile(file));
            Config = ModConfig.Load();
            MenuManager.Init();

            // Event handling
            Tick += OnTick;
            KeyDown += (o, e) =>
            {
                if (e.KeyCode == Config.DropMenu) // Our menu on/off switch
                    MenuManager.ShowMenu();
            };

            Notification.Show("~y~Just Cause Rebel Drops~w~ successfully loaded!");
        }

        public static void CallVehicleDrop(string VehicleModel)
        {
            // Drop setup
            if(PlaySound) AudioManager.PlaySound(DropSound.call);
            Model VModel = new Model(VehicleModel);
            Model CModel = new Model(Config.PlaneModel);
            if (!VModel.IsValid || !CModel.IsValid)
            {
                AudioManager.StopSound(DropSound.call);
                return;
            }

            // Drop continuation. This is only reached if the models were valid

            Vector3 PlanePos = Game.Player.Character.Position + Game.Player.Character.UpVector * 80f + Game.Player.Character.ForwardVector * -35f;
            Vector3 ContainerPos = Game.Player.Character.Position + Game.Player.Character.UpVector * 75f + Game.Player.Character.ForwardVector * 10f;

            // Vehicle spawning and adjustments
            Vehicle CargoPlane = World.CreateVehicle(CModel, PlanePos);
            CargoPlane.Heading = (Game.Player.Character.Position - CargoPlane.Position).ToHeading();
            VehicleDoor CargoDoor = CargoPlane.Doors.ToArray().FirstOrDefault(x => x.Index == VehicleDoorIndex.Trunk);
            VehicleDoor CargoDoor2 = CargoPlane.Doors.ToArray().FirstOrDefault(x => x.Index == VehicleDoorIndex.BackLeftDoor);
            if (CargoDoor != null) CargoDoor.Open(true, true);
            if (CargoDoor2 != null) CargoDoor2.Open(true, true);

            // Cargoplane pilot
            Vector3 FlyTo = Util.LerpByDistance(CargoPlane.Position, Game.Player.Character.Position, 5000f);
            Ped CargoPilot = CargoPlane.CreatePedOnSeat(VehicleSeat.Driver, new Model("s_m_m_pilot_02"));

            // Cargoplane AI
            Function.Call(Hash.SET_VEHICLE_FORWARD_SPEED, CargoPlane, 50f);
            Wait(500);
            Function.Call(Hash.TASK_PLANE_MISSION, CargoPilot, CargoPlane, 0, 0, FlyTo.X, FlyTo.Y, FlyTo.Z, 4, 100f, 0f, 90f, 0, 200f);

            // Container drop
            Prop Container = World.CreateProp(Globals.ContainerModel, ContainerPos, true, false);
            Container.HasGravity = true;
            Container.ApplyForce(new Vector3(0f, 0f, -35f));
            while (!Container.HasCollided)
                Wait(0);

            // Hit sound
            if (PlaySound)
            {
                AudioManager.StopSound(DropSound.call);
                AudioManager.PlaySound(DropSound.hit);
            }

            // Ensure the container is fully stopped
            Vector3 ContainerLastPos;
            do
            {
                ContainerLastPos = Container.Position;
                Wait(250);
            }
            while (Container.Position.DistanceTo(ContainerLastPos) > 0.1f);

            // Container opening
            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "proj_indep_firework_v2");
            Function.Call(Hash.USE_PARTICLE_FX_ASSET, "proj_indep_firework_v2");
            int ptfx = Function.Call<int>(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, "scr_firework_indep_ring_burst_rwb", Container, 0f, 0f, Container.Model.Dimensions.rearBottomLeft.X * 1f, 0f, 0f, 0f, 2f, true, true, true);
            Function.Call(Hash.SET_PARTICLE_FX_LOOPED_ALPHA, ptfx, 0.5f);
            Function.Call(Hash.SET_PARTICLE_FX_LOOPED_COLOUR, ptfx, 0.2f, 0.2f, 1f, true);
            Script.Wait(250);
            Vector3 SpawnPos = Container.Position;
            Container.Delete();

            // Vehicle moving
            Vehicle NewVehicle = World.CreateVehicle(VModel, SpawnPos);
            NewVehicle.PlaceOnGround();
            NewVehicle.IsPersistent = false;

            // Cleanup
            Wait(2500);
            if (!Config.FunMode)
            {
                CargoPilot.Task.ClearAll();
                CargoPlane.MarkAsNoLongerNeeded();
            }
            if(PlaySound) AudioManager.StopSound(DropSound.hit);
        }

        private void OnTick(object sender, EventArgs e)
        {
            MenuManager.MainPool.ProcessMenus();
        }
    }
}
