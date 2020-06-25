using CitizenFX.Core;

namespace Car_Carrier_Pursuit
{
    class Locations
    {
        private Vector3 truck_cord;
        private Vector3 trailer_cord;
        private Vector3 ped_cord;

        private int truck_heading;
        private int trailer_heading;
        private int ped_heading;

        /// <summary>
        /// Location object depending on where the callout should take place
        /// </summary>
        /// <param name="city">Choose from ls and sandy</param>
        /// <param name="choice">Choose location in the city</param>
        public Locations(string city, int choice) {

            if (city == "ls" && choice == 1) {

                this.truck_cord = new Vector3(-41.87F, -1076.49F, 26.74F);
                this.trailer_cord = new Vector3(-32.49F, -1080.07F, 26.66F);
                this.ped_cord = new Vector3(-44F, -1077.65F, 26.67F);

                this.truck_heading = 70;
                this.trailer_heading = truck_heading;
                this.ped_heading = 347;

            }
        
        }

        public Vector3 truckCords { get => truck_cord;}
        public Vector3 trailerCords { get => trailer_cord; }
        public Vector3 pedCords { get => ped_cord; }

        public int truckHeading { get => truck_heading; }
        public int trailerHeading { get => trailer_heading; }
        public int pedHeading { get => ped_heading; }

    }
}
