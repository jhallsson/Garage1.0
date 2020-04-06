using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    class Bus : Vehicle
    {
        private double length;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public Bus(double length, string regNumb, string color, int wheelCount)
            : base(regNumb, color, wheelCount)
        {
            Length = length;
        }
        public override string StringifyOutput(/*Vehicle vehicle*/)//ToDo: använd .tostring istället?
        {
            string vehicleInfo = $"{base.StringifyOutput(/*vehicle*/)}, {Length} m long.";
            return vehicleInfo;
        }
    }
}
