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
    }
}
