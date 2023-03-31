using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Input;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Runtime.Serialization;

namespace GarageCoreApp
{
    enum eCommands
    {
        INSERT_CAR = 1,
        CHANGE_STATUS,
        GET_VEHICLES,
        GET_PROFIT,
        EXIT
    }
    internal class GarageManager
    {
        public const int CAR_PRICE = 5000;
        public const int TRUCK_PRICE = 2000;
        public const int MOTORCYCLE_PRICE = 1000;

        public GarageData garageData;

       static string storagePath = "c:\\temp.json";
       
       public GarageManager()
        {
            this.initData();
        }

        public void start()
        {
            while (true)
            {
                try
                {
                    IOUtils.showMenu();
                    int input = IOUtils.getUserChosenOption();
                    this.performTask(input);
                }
                catch (Exception e)
                {
                    IOUtils.showError(e);
                }
            }
        }

        public void initData()
        {
           this.garageData = JsonGarageStorage.GetGarageData(storagePath);
        }

        void storeData()
        {
            JsonGarageStorage.storeGarageData(storagePath, this.garageData);
        }
        void insertVehicle()
        {
            
            (string licensePlate,int manufactureYear,string problemDescription, eVehicleTypes type)  = IOUtils.getBasicVehicleDetails();

            VehicleInGarage garageVehicle = new VehicleInGarage(problemDescription);

            switch (type)
            {
                case eVehicleTypes.CAR:
                    garageVehicle.Vehicle = new Car(licensePlate, manufactureYear);
                    garageVehicle.Price = CAR_PRICE;
                    break;

                case eVehicleTypes.TRUCK:
                    double weight = IOUtils.getTruckDetails();
                    garageVehicle.Vehicle = new Truck(licensePlate, manufactureYear, weight);
                    garageVehicle.Price = TRUCK_PRICE; 
                    break;

                case eVehicleTypes.MOTORCYCLE:
                    bool isExtraSeat = IOUtils.getMotorcycleDetails();
                    garageVehicle.Vehicle = new MotorCycle(licensePlate, manufactureYear, isExtraSeat);
                    garageVehicle.Price = MOTORCYCLE_PRICE;
                    break;


                default:
                    break;
            }

            this.garageData.AllVehicles.Add(licensePlate, garageVehicle);
            this.garageData.Profit += garageVehicle.Price;
            this.storeData();
        }

        void changeStatus()
        {
            (string licensePlate, eVehicleStatus status) = IOUtils.getChangeStatusInput();

            if(!garageData.AllVehicles.ContainsKey(licensePlate) )
            {
                IOUtils.showLog("Vehicle not found");
                return;
            }
  
            if (status == eVehicleStatus.RELEASED)
            {
                garageData.AllVehicles.Remove(licensePlate);
            }
            else
            {
                garageData.AllVehicles[licensePlate].Status = status;
            }

            this.storeData();

        }

        void getAllVehiclesByYear()
        {

            var vehiclesByYears = this.garageData.AllVehicles.Values.ToList().
                OrderBy(record => record.Vehicle.ManufactureYear);

            IOUtils.showVehiclesByYear(vehiclesByYears);
        }

        

        void exitProgram()
        {
            this.storeData();
            Environment.Exit(0);
        }

        public void performTask(int userInput)
        {
            eCommands command = (eCommands)userInput;
            
            switch (command)
            {
                case eCommands.INSERT_CAR:
                    insertVehicle();
                    break;

                case eCommands.CHANGE_STATUS:
                    changeStatus();
                    break;

                case eCommands.GET_VEHICLES:
                    this.getAllVehiclesByYear();
                    break;

                case eCommands.GET_PROFIT:
                    IOUtils.showProfit(this.garageData.Profit);
                    break;

                case eCommands.EXIT:
                    this.exitProgram();
                    break;


                default:
                    IOUtils.showLog("Invalid option");
                    break;
            }
        }

    }
}
