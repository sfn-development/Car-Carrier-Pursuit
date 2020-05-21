using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public CarCarrierPursuit() 
        { 
        
        
        
        }

        public override Task Init()
        {

            return base.Init();

        }
        public override void OnStart(Ped closest)
        {

            base.OnStart(closest);

        }

    }
}
