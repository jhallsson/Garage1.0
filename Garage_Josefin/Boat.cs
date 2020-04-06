using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    class Boat : Vehicle
    {
        private double draft;

        public double Draft
        {
            get { return draft; }
            set { draft = value; }
        }

        public Boat(double draft, string regNumb, string color, int wheelCount)
            : base(regNumb, color, wheelCount)
        {
            Draft = draft;
        }
        public override string StringifyOutput()//ToDo: använd .tostring istället?
        {
            string vehicleInfo = $"{base.StringifyOutput()}, draft: {Draft} m.";
            return vehicleInfo;
        }
    }
}
