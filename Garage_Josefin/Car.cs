using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    class Car : Vehicle
    {
        private string brand;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public Car(string brand, string regNumb, string color, int wheelCount)
            : base(regNumb, color, wheelCount)
        {
            Brand=brand;
        }
        public override string StringifyOutput()//ToDo: använd .tostring istället?
        {
            string vehicleInfo = $"{base.StringifyOutput()}, brand: {Brand}.";
            return vehicleInfo;
        }
    }
}
