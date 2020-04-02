using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_Josefin
{
    public class GarageHandler
    {
        Garage<Vehicle> garage;
        private Dictionary<string,Vehicle> types= new Dictionary<string, Vehicle>();

        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity); //ToDo: take in value for capacity
            garage.GarageCapacity = capacity;
            
        }
        
        public Vehicle CreateVehicle(string regNumb, string color, int wheelCount)
        {
                                                    //extra: color måste vara någon av förbestämd?
            Vehicle vehicle = new Vehicle(regNumb, color, wheelCount);
            
            return vehicle;                     //ToDo: inte kunna skapa utan ifyllda värden
        }
        public bool Park(Vehicle vehicle)   //ToDo: Gör om!!
        {
            int countBefore = CountVehicles();
            Vehicle emptyValue = garage.Vehicles.Where(v => v == null).FirstOrDefault();
            int emptyIndex = Array.IndexOf(garage.Vehicles, emptyValue);
           
            garage.Vehicles[emptyIndex] = vehicle;

            //int count = garage.Vehicles.Count(v => v is Vehicle); //ToDo:move
            
            int countAfter = CountVehicles();
            return countAfter > countBefore; //statement: true/false smart!!!
        }

        public bool Leave(string regNr)
        {
            int countBefore = CountVehicles();
            string search = regNr.ToUpper();
                                                            //input => method body
            Vehicle vehicleLeaving = garage.Vehicles?.Where(v => v.RegNumb == search).FirstOrDefault();
            int index = Array.IndexOf(garage.Vehicles, vehicleLeaving);
            garage.Vehicles[index] = null;
            int countAfter = CountVehicles();
            return countBefore > countAfter; //ToDo: bool eller vehicle?
             
        }

        public void ListVehicles() 
        {
            foreach (var vehicle in garage.Vehicles)
            {
                string info = StringifyOutput(vehicle);
                UI.Print(info);
            }
        }

        internal void ListVehicleTypes(string type)
        {
            //ToDo: dictionary? -> string + vehicle subklass
            //if type= key lista alla i subklass
        }

        public string Search(string regNr) //ToDo: understand ?-nullcheck / gör om
        {
            regNr = regNr.ToUpper();            //ToDo: .toUpper fult/fel plats?
            Vehicle vehicle = garage.Vehicles?.Where(v => v?.RegNumb == regNr).FirstOrDefault(); 
            int index = Array.IndexOf(garage.Vehicles, vehicle);
            return StringifyOutput(vehicle);
        }
        public string StringifyOutput(Vehicle vehicle)
        {
            string vehicleInfo = $"Vehicle: {vehicle.RegNumb}, color: {vehicle.Color}, {vehicle.WheelCount} wheels.";

            return vehicleInfo;
        }
        public int CountVehicles()
        {
            int count = garage.Vehicles.Count(v => v is Vehicle);
            return count;
        }
    }
}
