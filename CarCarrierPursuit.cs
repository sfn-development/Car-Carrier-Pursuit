using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CitizenFX.Core;
using CalloutAPI;

namespace Car_Carrier_Pursuit
{

    [GuidAttribute("9d3946b1-370d-475e-9b70-99263f12ebd9")]
    [CalloutProperties("Car Carrier Pursuit", "SFN-Development", "1.0.0", Callout.Probability.Medium)]
    public class CarCarrierPursuit : CalloutAPI.Callout
    {

        /*Truck Variables*/
        Model phantom = new Model(VehicleHash.Phantom);
        Vector3 truckCord = new Vector3(-41.87F, -1076.49F, 26.74F);
        int truckHeading = 70;
        Vehicle truck;

        /*Trailer Variables*/
        Model carCarrier = new Model(VehicleHash.TR4);
        Vector3 carCarrierCords = new Vector3(-32.49F, -1080.07F, 26.66F);
        Vehicle trailer;

        /*Ped Variables*/
        Ped suspect;
        Vector3 suspectCords = new Vector3(-44F, -1077.65F, 26.67F);
        int suspectHeading = 347;

        public CarCarrierPursuit() 
        {
            if (System.Math.Abs(Game.PlayerPed.GetPositionOffset(truckCord).X) < 2000)
            {
                InitBase(truckCord);
                this.ShortName = "Car Carrier Pursuit";
                this.CalloutDescription = "There are reports of someone trying to steal a car-carrier from the Premium Deluxe Motorsport's car dealership. Stop the suspects and return the truck and cars to the dealership.";
                this.ResponseCode = 3;
                this.StartDistance = 120f;
            }
            else {
                Debug.WriteLine("~r~[Car Carrier Pursuit Callout]: ~w~Player is too far away to start the callout");            
            }
        }

        public async override Task Init()
        {
            this.OnAccept(15, BlipColor.Red);
            truck = await World.CreateVehicle(phantom, truckCord, truckHeading);
            trailer = await World.CreateVehicle(carCarrier, carCarrierCords, truckHeading);

            CitizenFX.Core.Native.API.AttachVehicleToTrailer(truck.GetHashCode(), trailer.GetHashCode(), 1F);
            suspect = await SpawnPed(GetRandomPed(), suspectCords, suspectHeading);
            suspect.AlwaysKeepTask = true;
            Notify("~g~[Dispatch]: ~w~There are reports of a subject breaking into a car carrier.");
            Notify("~g~[Dispatch]: ~w~Get to the scene and apprehend the suspect.");
            Notify("~r~[Callout]: ~w~Call for backup once you have arrived to the dealership.");

        }
        public async override void OnStart(Ped closest)
        {

            /*Dispatch Notification*/
            Notify("~g~[Dispatch]: ~w~The truck has a tracker on it. See your map for location details");

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

        public void Notify(String message)
        {
            CitizenFX.Core.Native.API.BeginTextCommandThefeedPost("STRING");
            CitizenFX.Core.Native.API.AddTextComponentSubstringPlayerName(message);
            CitizenFX.Core.Native.API.EndTextCommandThefeedPostTicker(false, true);
        }
    }
}
