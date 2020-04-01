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
        /*public Garage<Vehicle> CreateGarage(int capacity) //konstruktor?
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity); //ToDo: take in value for capacity
            garage.GarageCapacity = capacity;
            return garage;
        }*/
        public Vehicle CreateVehicle(string regNumb, string color, int wheelCount)
        {
            Vehicle vehicle = new Vehicle(regNumb, color, wheelCount);
            return vehicle;
        }
        public bool Park(Vehicle vehicle)   //ToDo: Gör om!!
        {
            Vehicle emptyValue = garage.Vehicles.Where(v => v == null).FirstOrDefault();
            
            int emptyIndex = Array.IndexOf(garage.Vehicles, emptyValue);
           
            garage.Vehicles[emptyIndex] = vehicle;

            int count = garage.Vehicles.Count(v => v is Vehicle); 
             return true;
        }

        public Vehicle Leave(string regNr)
        {
            Vehicle vehicleLeaving = garage.Vehicles.Where(v => v.RegNumb == regNr).FirstOrDefault();
            int index = Array.IndexOf(garage.Vehicles, vehicleLeaving);

            for (int i = index; i < garage.Vehicles.Length; i++)
            {   //0                 3
                garage.Vehicles[i] = garage.Vehicles[i++];
                // ABC      =       DEF 
                //DEF       =       null
            }

            return vehicleLeaving; //ToDo: bool eller vehicle?
        }

        internal bool ListVehicles()
        {
            throw new NotImplementedException();
        }

        internal bool ListVehicleTypes()
        {
            throw new NotImplementedException();
        }

        internal bool Search(string regNr)
        {
            Vehicle vehicleLeaving = garage.Where(v => v.RegNumb == regNr).FirstOrDefault();
            int index = Array.IndexOf(garage.Vehicles, vehicleLeaving);
            return true;
        }
    }
}
