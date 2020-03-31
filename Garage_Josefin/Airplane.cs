using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    class Airplane : Vehicle
    {
        private int seats;

        public int Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        public Airplane(int seats, string regNumb, string color, int wheelCount) 
            : base(regNumb,color,wheelCount)
        {
            Seats = seats;
        }
    }
}
