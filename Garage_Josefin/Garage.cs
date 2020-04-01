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

        public Vehicle[] Vehicles 
        { 
            get => vehicles; 
            set => vehicles = value; //park sätter värden? inte för hela utan index
        }

        public Garage(int capacity){
            GarageCapacity = Math.Max(0, capacity);     //aldrig mindre än 0
            //GarageCapacity = capacity;
            Vehicles = new Vehicle[GarageCapacity];     //array lika stor som garaget
        }

        
        public IEnumerator<T> GetEnumerator() //ToDo: implementera
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        
    }
}
