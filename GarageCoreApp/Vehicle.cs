using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json.Serialization;


namespace GarageCoreApp
{
    public enum eVehicleTypes
    {
        CAR = 1,
        TRUCK,
        MOTORCYCLE,
        
    }
    public class Vehicle
    {
        protected string licensePlate;

        protected int manufactureYear;

        protected eVehicleTypes vehicleType;

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }
            set
            {
                this.licensePlate = value;
            }
        }

        public int ManufactureYear
        {
            get
            {
                return this.manufactureYear;
            }
            set
            {
                this.manufactureYear = value;
            }
        }

        public eVehicleTypes VehicleType
        {
            get
            {
                return this.vehicleType;
            }
            set
            {
                this.vehicleType = value;
            }
        }


        public Vehicle()
        {

        }

        
        public Vehicle(string licensePlate, int manufactureYear)
        {
            this.licensePlate = licensePlate;
            this.manufactureYear = manufactureYear;
        }

      
        public override string ToString()
        {
            return $"license plate: {licensePlate} , manufacture year: {manufactureYear} , type:{vehicleType}";
        }
        

    }





}
