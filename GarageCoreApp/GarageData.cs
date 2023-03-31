using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageCoreApp
{
    internal class GarageData
    {

        private int profit;

        private Dictionary<string, VehicleInGarage> allVehicles;

        public int Profit
        {
            get
            {
                return this.profit;
            }
            set
            {
                this.profit = value;
            }
        }


        public Dictionary<string, VehicleInGarage> AllVehicles
        {
            get
            {
                return this.allVehicles;
            }
            set
            {
                this.allVehicles = value;
            }
        }

        public GarageData(GarageData data)
        {
            this.profit = data.profit;
            this.allVehicles = data.allVehicles;
        }

        public GarageData() { 
            this.allVehicles = new Dictionary<string, VehicleInGarage>();
            this.profit = 0; 
        }
    }
}
