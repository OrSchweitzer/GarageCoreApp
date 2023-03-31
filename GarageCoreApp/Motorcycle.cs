using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GarageCoreApp
{
    internal class MotorCycle : Vehicle
    {

        public bool extrasSeat;

        public bool ExtraSeat
        {
            get
            {
                return extrasSeat;
            }
            set
            {
                this.extrasSeat = value;
            }
        }


        public MotorCycle()
        {

        }

        
        public MotorCycle(string licensePlate, int manufactureYear, bool extraSeat) 
            : base(licensePlate, manufactureYear)
        {
            this.vehicleType = eVehicleTypes.MOTORCYCLE;
            this.extrasSeat = extraSeat;
        }



    }
}
