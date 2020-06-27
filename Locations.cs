﻿using CitizenFX.Core;

namespace Car_Carrier_Pursuit
{
    class Locations
    {
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
        /// <param name="choice">Choose location in the city</param>
        /// <param name="dest">Choose destination location</param>
        public Locations(string city, int choice, int dest) {

            /*Spawn Cords and Headings*/

            //Premium Deluxe Power Street
            if (city == "ls" && choice == 1) 
            {
                this.truck_cord = new Vector3(-41.87F, -1076.49F, 26.74F);
                this.trailer_cord = new Vector3(-32.49F, -1080.07F, 26.66F);
                this.driver_cord = new Vector3(-44F, -1077.65F, 26.67F);

                this.TruckHeading = 70;
                this.TrailerHeading = TruckHeading;
                this.DriverHeading = 347;

            }

            /*Destination Cords and headings*/

            //Paleto BayView Lodge
            if (dest == 1) {

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

            }
            //TO-DO add destinations with elseif. 

        }

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
