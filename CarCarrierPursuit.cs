using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CitizenFX.Core;
using FivePD.API;
using System.Collections.Generic;

namespace Car_Carrier_Pursuit
{

    [GuidAttribute("9d3946b1-370d-475e-9b70-99263f12ebd9")]
    [CalloutProperties("Car Carrier Pursuit", "SFN-Development", "1.0.1")]
    public class CarCarrierPursuit : FivePD.API.Callout
    {

        //Initalize Global Location and Heading Dictionaries
        readonly Locations locations;

        /*Truck Variables*/
        Model phantom = new Model(VehicleHash.Phantom);
        Vehicle truck;

        /*Trailer Variables*/
        Model carCarrier = new Model(VehicleHash.TR4);
        Vehicle trailer;

        /*Ped Variables*/
        Ped suspect;

        public CarCarrierPursuit() 
        {
            locations = new Locations("ls", 1);
            InitInfo(locations.truckCords);
            this.ShortName = "Car Carrier Pursuit";
            this.CalloutDescription = "There are reports of someone trying to steal a car-carrier from the Premium Deluxe Motorsport's car dealership. Stop the suspects and return the truck and cars to the dealership.";
            this.ResponseCode = 3;
            this.StartDistance = 90f;
            
        }

        public async override Task OnAccept()
        {
            this.InitBlip(15, BlipColor.Red);
            truck = await World.CreateVehicle(phantom, locations.truckCords, locations.truckHeading);
            trailer = await World.CreateVehicle(carCarrier, locations.trailerCords, locations.trailerHeading);

            CitizenFX.Core.Native.API.AttachVehicleToTrailer(truck.GetHashCode(), trailer.GetHashCode(), 1F);
            suspect = await SpawnPed(GetRandomPed(), locations.pedCords, locations.pedHeading);
            suspect.AlwaysKeepTask = true;
            Notify("There are reports of a subject breaking into a car carrier.");
            Notify("Get to the scene and investigate the area.");

        }
        public async override void OnStart(Ped closest)
        {

            /*Dispatch Notification*/
            Notify("The truck has a tracker on it. See your map for location details.");

            /*Cords for person to drive to.*/
            Random rand = new Random();
            float xoff = rand.Next(1000, 2000);
            float yoff = rand.Next(1000, 2000);

            Debug.WriteLine(xoff.ToString() + " " + yoff.ToString());

            base.OnStart(closest);

            suspect.Task.EnterVehicle(truck, VehicleSeat.Driver);
            truck.TowVehicle(trailer, false);
            suspect.DrivingStyle = DrivingStyle.Rushed;
            suspect.Task.DriveTo(truck, new Vector3(xoff, yoff, 0F), 1000F, 100F, 0);

            Marker.Delete();
            truck.AttachBlip().ShowRoute = true;
            
            for (int i = 0; i < rand.Next(4,10); i++) {
                await BaseScript.Delay(rand.Next(120000,180000));
                xoff = rand.Next(2001, 6000);
                yoff = rand.Next(2001, 6000);

                if (rand.Next(1, 2) == 1) {
                    xoff = xoff * -1;
                }
                if (rand.Next(1, 2) == 1)
                {
                    yoff = yoff * -1;
                }
                suspect.Task.DriveTo(truck, new Vector3(xoff, yoff, 0F), 500F, 120F);

                Debug.WriteLine(xoff.ToString() + " " + yoff.ToString());
            }
        }

        public void Notify(string message)
        {

            ShowNetworkedNotification(message, "CHAR_CALL911", "CHAR_CALL911", "Dispatch", "Car Carrier Pursuit", 15f);

        }
    }
}
