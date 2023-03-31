using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GarageCoreApp
{
    public class Truck : Vehicle
    {

        protected double weight;

        public double Weightlimit
        {
            get
            {
                return weight;
            }
            set
            {
                this.weight = value;
            }
        }


        public Truck()
        {

        }
       

        public Truck(string licensePlate, int manufactureYear, double weight):
            base(licensePlate, manufactureYear)
        {
            
            this.vehicleType = eVehicleTypes.TRUCK;
            this.weight = weight;
        }

    }
}
