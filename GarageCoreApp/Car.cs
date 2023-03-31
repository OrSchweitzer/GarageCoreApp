using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GarageCoreApp
{
    public class Car : Vehicle
    {

        public Car()
        {

        }

        public Car(string licensePlate, int manufactureYear)
            : base(licensePlate, manufactureYear)
        {
            this.vehicleType = eVehicleTypes.CAR;
        }
    }
}
