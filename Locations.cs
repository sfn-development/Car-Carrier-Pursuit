using CitizenFX.Core;

namespace Car_Carrier_Pursuit
{
    class Locations
    {
        /*Callout Descriptions*/
        private string description;

        /*Spawn Locations*/
        private Vector3 truck_cord;
        private Vector3 trailer_cord;
        private Vector3 driver_cord;

        /*Destination Locations*/
        private Vector3 destination_cord;

        //Car1
        private Vector3 enemyCar1_cords;
        private Vector3 ped1_cords;
        private Vector3 ped2_cords;

        //Car2
        private Vector3 enemyCar2_cords;
        private Vector3 ped3_cords;
        private Vector3 ped4_cords;

        /// <summary>
        /// Location object depending on where the callout should take place
        /// </summary>
        /// <param name="city">Choose from ls and sandy</param>
        /// <param name="start">Choose location in the city</param>
        /// <param name="dest">Choose destination location</param>
        public Locations(string city, int start, int dest) {

            /*Spawn Cords and Headings*/

            //Premium Deluxe Power Street
            if (city == "ls" && start == 1)
            {
                this.description = "There are reports of someone trying to steal a car-carrier from the Premium Deluxe Motorsport's car dealership. Stop the suspect and return the truck and cars to the dealership.";

                this.truck_cord = new Vector3(-41.87F, -1076.49F, 26.74F);
                this.trailer_cord = new Vector3(-32.49F, -1080.07F, 26.66F);
                this.driver_cord = new Vector3(-44F, -1077.65F, 26.67F);

                this.TruckHeading = 70;
                this.TrailerHeading = TruckHeading;
                this.DriverHeading = 347;
            }
            //Larry's RV Sales Route 68
            else if (city == "sandy" && start == 1) 
            {
                this.description = "There are reports of someone trying to steal a car-carrier from the Larry's RV Sales. Stop the suspect and return the truck and cars to the dealership.";

                this.truck_cord = new Vector3(1250.33F, 2701.45F, 38.06F);
                this.trailer_cord = new Vector3(1249.37F, 2711.1F, 38.06F);
                this.driver_cord = new Vector3(1252.95F, 2699.59F, 38.01F);

                this.TruckHeading = 185;
                this.TrailerHeading = TruckHeading;
                this.DriverHeading = 96;
            }

            /*Destination Cords and headings*/
            switch (dest) 
            {
                //Paleto BayView Lodge
                case 1:
                    this.destination_cord = new Vector3(-672.09F, 5788.22F, 17.34F);

                    //Car 1
                    this.enemyCar1_cords = new Vector3(-716.28F, 5768.2F, 17.07F);
                    this.Car1Heading = 17;

                    //Peds for car 1
                    this.ped1_cords = new Vector3(-710.16F, 5786.01F, 17.36F);
                    this.Ped1Heading = 128;
                    this.ped2_cords = new Vector3(-691.67F, 5780.69F, 17.33F);
                    this.Ped2Heading = 92;

                    //Car 2
                    this.enemyCar2_cords = new Vector3(-708.72F, 5784.58F, 16.89F);
                    this.Car2Heading = 120;

                    //Peds for car 2
                    this.ped3_cords = new Vector3(-718.23F, 5766.41F, 17.61F);
                    this.Ped3Heading = 40;
                    this.ped4_cords = new Vector3(-689.35F, 5762.43F, 17.33F);
                    this.Ped4Heading = 45;
                    break;
                case 2:
                    this.destination_cord = new Vector3(1358.6F, -735.46F, 67.23F);

                    //Car 1
                    this.enemyCar1_cords = new Vector3(1331.62F, -733.38F, 65.81F);
                    this.Car1Heading = 44;

                    //Peds for car 1
                    this.ped1_cords = new Vector3(1329.4F, -731.8F, 66.11F);
                    this.Ped1Heading = 71;
                    this.ped2_cords = new Vector3(1343.44F, -757.97F, 67.67F);
                    this.Ped2Heading = 32;

                    //Car 2
                    this.enemyCar2_cords = new Vector3(1334.74F, -725.32F, 65.86F);
                    this.Car2Heading = 97;

                    //Peds for car 2
                    this.ped3_cords = new Vector3(1332.12F, -725.53F, 66.18F);
                    this.Ped3Heading = 61;
                    this.ped4_cords = new Vector3(1353.82F, -710.93F, 67.24F);
                    this.Ped4Heading = 113;
                    break;
                case 3:
                    this.destination_cord = new Vector3(134.7F, -3333.54F, 6.02F);

                    //Car 1
                    this.enemyCar1_cords = new Vector3(152.07F, -3338.08F, 5.59F);
                    this.Car1Heading = 305;

                    //Peds for car 1
                    this.ped1_cords = new Vector3(154.33F, -3336.82F, 6.02F);
                    this.Ped1Heading = 308;
                    this.ped2_cords = new Vector3(155.23F, -3323.08F, 15.99F);
                    this.Ped2Heading = 265;

                    //Car 2
                    this.enemyCar2_cords = new Vector3(151.87F, -3326.77F, 5.59F);
                    this.Car2Heading = 270;

                    //Peds for car 2
                    this.ped3_cords = new Vector3(154.52F, -3326.8F, 6.02F);
                    this.Ped3Heading = 244;
                    this.ped4_cords = new Vector3(115.9F, -3323.9F, 6.01F);
                    this.Ped4Heading = 22;
                    break;
                case 4:
                    this.destination_cord = new Vector3(81.5F, 3670.22F, 39.4F);

                    //Car 1
                    this.enemyCar1_cords = new Vector3(70.59F, 3621.27F, 39.24F);
                    this.Car1Heading = 211;

                    //Peds for car 1
                    this.ped1_cords = new Vector3(71.97F, 3618.95F, 39.74F);
                    this.Ped1Heading = 220;
                    this.ped2_cords = new Vector3(55.09F, 3638.7F, 39.5F);
                    this.Ped2Heading = 195;

                    //Car 2
                    this.enemyCar2_cords = new Vector3(89.79F, 3624.18F, 39.31F);
                    this.Car2Heading = 144;

                    //Peds for car 2
                    this.ped3_cords = new Vector3(88.27F, 3621.99F, 39.82F);
                    this.Ped3Heading = 141;
                    this.ped4_cords = new Vector3(103.09F, 3644.17F, 39.75F);
                    this.Ped4Heading = 145;
                    break;

            }
            //TO-DO add destinations with elseif. 

        }

        /*Description Getter*/
        public string CalloutDescription { get => this.description; }

        /*Spawn Locations Getters*/
        public Vector3 TruckCords { get => truck_cord;}
        public Vector3 TrailerCords { get => trailer_cord; }
        public Vector3 DriverCords { get => driver_cord; }
       
        public int TruckHeading { get; }
        public int TrailerHeading { get; }
        public int DriverHeading { get; }

        /*Destination Location Getters*/
        public Vector3 DestinationCords { get => this.destination_cord; }

        //Car1
        public Vector3 Car1Cords { get => this.enemyCar1_cords; }
        public int Car1Heading { get; }

        //Peds car 1
        public Vector3 Ped1Cords { get => this.ped1_cords; }
        public int Ped1Heading { get; }

        public Vector3 Ped2Cords { get => this.ped2_cords; }
        public int Ped2Heading { get; }

        //Car 2
        public Vector3 Car2Cords { get => this.enemyCar2_cords; }
        public int Car2Heading { get; }

        //Peds car 2
        public Vector3 Ped3Cords { get => this.ped3_cords; }
        public int Ped3Heading { get; }
        public Vector3 Ped4Cords { get => this.ped4_cords; }
        public int Ped4Heading { get; }
    }
}
