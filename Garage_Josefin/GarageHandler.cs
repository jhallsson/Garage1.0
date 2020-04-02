using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_Josefin
{
    public class GarageHandler
    {
        Garage<Vehicle> garage;


        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity); //ToDo: take in value for capacity
            garage.GarageCapacity = capacity;
            
        }
        
        public Vehicle CreateVehicle(string regNumb, string color, int wheelCount)
        {
            Vehicle vehicle = new Vehicle(regNumb, color, wheelCount);
            return vehicle;
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

        public Vehicle Leave(string regNr)
        {                                                   //input => method body
            Vehicle vehicleLeaving = garage.Vehicles?.Where(v => v.RegNumb == regNr).FirstOrDefault();
            int index = Array.IndexOf(garage.Vehicles, vehicleLeaving);

            for (int i = index; i < garage.Vehicles.Length; i++)
            {   //0                 3
                garage.Vehicles[i] = garage.Vehicles[i++];
                // ABC      =       DEF 
                //DEF       =       null
            }
            return vehicleLeaving; //ToDo: bool eller vehicle?
        }

        public void ListVehicles() //eller egentligen T?
        {
            //count
            //iterate all 
            //send to UI as message
            //yeild?

            foreach (var vehicle in garage.Vehicles)
            {
                string info = StringifyOutput(vehicle);
                UI.Print(info);
            }
        }

        internal bool ListVehicleTypes()
        {
            throw new NotImplementedException();
        }

        public string Search(string regNr) //ToDo: understand ?-nullcheck
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
