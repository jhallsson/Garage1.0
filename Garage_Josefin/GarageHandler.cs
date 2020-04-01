using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_Josefin
{
    public class GarageHandler
    {
        

        public Garage<Vehicle> CreateGarage(int capacity) //konstruktor?
        {
            Garage<Vehicle> garage = new Garage<Vehicle>(capacity); //ToDo: take in value for capacity
            garage.GarageCapacity = capacity;
            return garage;
        }
        public bool Park(Vehicle vehicle, Garage<Vehicle> garage)   //ToDo: Gör om!!
        {
            Vehicle emptyValue = garage.Vehicles.Where(v => v == null).FirstOrDefault();
            
            int emptyIndex = Array.IndexOf(garage.Vehicles, emptyValue);
           
            garage.Vehicles[emptyIndex] = vehicle;

            int count = garage.Vehicles.Count(v => v is Vehicle); 
             return true;
        }

        public bool Leave(string regNr, Garage<Vehicle> garage)
        {
            Vehicle vehicleLeaving = garage.Where(v => v.RegNumb == regNr).FirstOrDefault();
            int index = Array.IndexOf(garage.Vehicles, vehicleLeaving);

            for (int i = index; i < garage.Vehicles.Length; i++)
            {   //0                 3
                garage.Vehicles[i] = garage.Vehicles[i++];
                // ABC      =       DEF 
                //DEF       =       null
            }

            return true;
        }
    }
}
