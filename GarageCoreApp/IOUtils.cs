using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageCoreApp
{
    internal class IOUtils
    {

        public static void showMenu()
        {
            Console.WriteLine(string.Format(
@"Choose an option:
1. Insert new vehicle.
2. Change status of vehicle.
3. Get all vehicles sorted by manufacturing year.
4. Get total profit.
5. Exit."));
        }

        public static int getUserChosenOption()
        {
            string strInput = Console.ReadLine();
            int option = int.Parse(strInput);
            return option;
            
        }
       
        public static void showProfit(int profit)
        {
            Console.WriteLine($"Profit is {profit}$");
        }

        public static void showVehiclesByYear(IOrderedEnumerable<VehicleInGarage> vehiclesInGarage)
        {
            foreach (var item in vehiclesInGarage)
            {
                Console.WriteLine(item);
            }
        }

        public static (string, eVehicleStatus) getChangeStatusInput()
        {
            string plate = getLicensePlateNumber();
            eVehicleStatus status = getStatus();

            return (plate, status);
        }

        public static eVehicleStatus getStatus()
        {
            Console.WriteLine(string.Format(
                @"Please enter status of vehicle : 
1.New 
2.In Process 
3.Fixed
4.Released"));
            eVehicleStatus status = (eVehicleStatus) getUserChosenOption();

            return status;
        }

        public static string getLicensePlateNumber()
        {
            Console.WriteLine("Please enter license plate");
            string licensePlate = Console.ReadLine();

            return licensePlate;
        }
        
        public static (string, int,string, eVehicleTypes) getBasicVehicleDetails()
        {
            Console.WriteLine("Please enter type of vehicle : 1.Car 2.Truck 3.Motorcycle");
            eVehicleTypes type = (eVehicleTypes) getUserChosenOption();
            string licensePlate = getLicensePlateNumber();
            Console.WriteLine("Please enter year of manufacture");
            int manufactureYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter problem description");
            string problemDescription = Console.ReadLine(); 

            return (licensePlate, manufactureYear, problemDescription, type);
           
        }

        public static double getTruckDetails()
        {
            Console.WriteLine("Please enter weight limit");
            double weight = double.Parse(Console.ReadLine());

            return weight;
        }

        public static bool getMotorcycleDetails()
        {
            Console.WriteLine("Please enter if you have an extra seat? 1.Yes 2.No");
            bool isextraSeat = (Console.ReadLine() == "1");

            return isextraSeat;

        }

        public static void showError(Exception e)
        {
            Console.WriteLine("Something went wrong");
            Console.WriteLine(e.Message);
        }

        public static void showLog(string log)
        {
            Console.WriteLine(log);
        }
 
    }
}
