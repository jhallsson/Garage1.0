using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        
        private int garageCapacity;
        private Vehicle[] vehicles;

        public int GarageCapacity
        {
            get { return garageCapacity; }
            set { garageCapacity = value; }
        }

        public Garage(int capacity){
            GarageCapacity = capacity;
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int AddVehicle(Vehicle vehicle)
        {
            vehicles = new Vehicle[GarageCapacity]; //ToDo: bestäm med garagecapacity första gången?
            vehicles[0] = vehicle;
            return vehicles.Length;
        }
    }
}
