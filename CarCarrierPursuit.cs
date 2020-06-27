using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CitizenFX.Core;
using FivePD.API;
using CitizenFX.Core.Native;

namespace Car_Carrier_Pursuit
{

    [GuidAttribute("9d3946b1-370d-475e-9b70-99263f12ebd9")]
    [CalloutProperties("Car Carrier Pursuit", "SFN-Development", "1.0.2")]
    public class CarCarrierPursuit : Callout
    {
       
        /*Department Locations*/
        Vector3 MISSON_ROW = new Vector3(428F, -980F, 30F);
        Vector3 SANDY_SHORES = new Vector3(1852F, 3688F, 34F);

        /*Check Variables Needed for pursuit*/
        bool pursuit = true;
        bool destinationSpawn = false;

        //Initalize global location and heading object
        readonly Locations locations;

        /*Truck Variables*/
        readonly Model phantom = new Model(VehicleHash.Phantom);
        Vehicle truck;

        /*Trailer Variables*/
        readonly Model carCarrier = new Model(VehicleHash.TR4);
        Vehicle trailer;

        /*Ped Variables - Person driving the truck*/
        Ped driver;

        /*Other Suspect - Gang that is waiting for the car trailer at the destination*/

        //Cars
        readonly Model dubsta2 = new Model(VehicleHash.Dubsta2);
        Vehicle car1;
        Vehicle car2;

        //Peds
        Ped ped1;
        Ped ped2;
        Ped ped3;
        Ped ped4;

        

        public CarCarrierPursuit() 
        {

            if (World.GetDistance(Game.PlayerPed.Position, MISSON_ROW) < World.GetDistance(Game.PlayerPed.Position, SANDY_SHORES))
            {
                locations = new Locations("ls", 1, 1);
            }
            else 
            {
                locations = new Locations("sandy", 1, 1);
            }

            this.InitInfo(locations.TruckCords);
            this.ShortName = "Car Carrier Pursuit";
            this.ResponseCode = 3;
            this.StartDistance = 90f;
            this.CalloutDescription = locations.CalloutDescription;
            

        }

        //When user accepts callout
        public async override Task OnAccept()
        {
            this.InitBlip(15, BlipColor.Red);
            truck = await World.CreateVehicle(phantom, locations.TruckCords, locations.TruckHeading);
            trailer = await World.CreateVehicle(carCarrier, locations.TrailerCords, locations.TrailerHeading);

            API.AttachVehicleToTrailer(truck.GetHashCode(), trailer.GetHashCode(), 1F);
            driver = await SpawnPed(PedHash.Michael, locations.DriverCords, locations.DriverHeading);
            driver.RelationshipGroup = "PRIVATE_SECURITY";
            Notify("There are reports of a subject breaking into a car carrier.");
            Notify("Get to the scene and investigate the area.");

        }

        //When user arrives on scene
        public async override void OnStart(Ped closest)
        {

            /*Dispatch Notification*/
            Notify("Looks like the suspect is taking off.");
            Notify("The truck has a tracker on it. See your map for location details.");

            base.OnStart(closest);

            //All Suspect Tasks
            driver.Weapons.Give(WeaponHash.Pistol, 100, true, true);

            driver.AlwaysKeepTask = true;
            driver.Task.EnterVehicle(truck, VehicleSeat.Driver);
            truck.TowVehicle(trailer, false);
            //https://www.vespura.com/fivem/drivingstyle/ is a god send
            driver.Task.DriveTo(truck, locations.DestinationCords, 0F, 100F, 524844);

            Marker.Delete();
            truck.AttachBlip().ShowRoute = true;

            while (pursuit) {

                //Checks if the suspect is within a certain distance of the destination every 4 seconds 
                await BaseScript.Delay(4000);
                float distance = truck.Position.DistanceToSquared(locations.DestinationCords);
                if (distance < 2000F) {

                    pursuit = false;
                    break;
                }

                //Check if the truck has stopped
                if (truck.Speed == 0F) {
                    await BaseScript.Delay(7000);
                    if (truck.Speed == 0F) {
                        pursuit = false;
                        break; 
                    }
                }

                //Spawns destination entities when the pursuit is close to it.
                if (distance < 50000F && !destinationSpawn) {

                    car1 = await World.CreateVehicle(dubsta2, locations.Car1Cords, locations.Car1Heading);
                    car2 = await World.CreateVehicle(dubsta2, locations.Car2Cords, locations.Car2Heading);

                    ped1 = await SpawnPed(PedHash.Business01AMM, locations.Ped1Cords, locations.Ped1Heading);
                    ped1.Weapons.Give(WeaponHash.AssaultRifleMk2,100, true, true);
                    ped1.AlwaysKeepTask = true;
                    ped1.Task.GuardCurrentPosition();
                    ped1.RelationshipGroup = "PRIVATE_SECURITY";

                    ped2 = await SpawnPed(PedHash.Business01AMY, locations.Ped2Cords, locations.Ped2Heading);
                    ped2.Weapons.Give(WeaponHash.AssaultRifleMk2, 100, true, true);
                    ped2.AlwaysKeepTask = true;
                    ped2.Task.GuardCurrentPosition();
                    ped2.RelationshipGroup = "PRIVATE_SECURITY";

                    ped3 = await SpawnPed(PedHash.FbiSuit01, locations.Ped3Cords, locations.Ped3Heading);
                    ped3.Weapons.Give(WeaponHash.AssaultRifleMk2, 100, true, true);
                    ped3.AlwaysKeepTask = true;
                    ped3.Task.GuardCurrentPosition();
                    ped3.RelationshipGroup = "PRIVATE_SECURITY";

                    ped4 = await SpawnPed(PedHash.FbiSuit01Cutscene, locations.Ped4Cords, locations.Ped4Heading);
                    ped4.Weapons.Give(WeaponHash.AssaultRifleMk2, 100, true, true);
                    ped4.AlwaysKeepTask = true;
                    ped4.Task.GuardCurrentPosition();
                    ped4.RelationshipGroup = "PRIVATE_SECURITY";

                    destinationSpawn = true;

                }
            
            }

            driver.Task.LeaveVehicle(LeaveVehicleFlags.LeaveDoorOpen);
            driver.Task.FightAgainst(closest);

            if (ped1 != null) {
                ped1.Task.FightAgainst(closest);
                ped2.Task.FightAgainst(closest);
                ped3.Task.FightAgainst(closest);
                ped4.Task.FightAgainst(closest);
            }
            


        }

        public override void OnCancelBefore()
        {
            //Deletes all destination peds but will keep the car carrier
            base.OnCancelBefore();
            ped1 = null;
            ped2 = null;
            ped3 = null;
            ped4 = null;
            car1 = null;
            car2 = null;
        }

        public void Notify(string message)
        {
            ShowNetworkedNotification(message, "CHAR_CALL911", "CHAR_CALL911", "Dispatch", "Car Carrier Pursuit", 15f);
        }

    }
}
