using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageCoreApp
{

    enum eVehicleStatus
    {
        NEW = 1,
        IN_PROCESS,
        FIXED,
        RELEASED,

    }
    internal class VehicleInGarage
    {
        private Vehicle vehicle;

        private eVehicleStatus status;

        private string problem;

        private int price;


        public int Price
        {
            get { 
                return this.price; 
            }
            set
            {
                this.price = value;
            }
        }


        public Vehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            set
            {
                this.vehicle = value;
            }
        }


        public eVehicleStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

     

        public string Problem
        {
            get
            {
                return this.problem;
            }
            set
            {
                this.problem = value;
            }
        }
        public VehicleInGarage()
        {

        }

        public VehicleInGarage(string problem)
        {
            this.status = eVehicleStatus.NEW;
            this.problem = problem;
        }

        public override string ToString()
        {
            return $"{vehicle} , status : {status}";
        }
    }
}
