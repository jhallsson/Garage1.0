using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    public class Vehicle
    {
		private string regNumb;

		public string RegNumb
		{
			get { return regNumb; }
			set { regNumb = value.ToUpper(); } //ToDo: Rätt plats?
		}
		private string color;

		public string Color
		{
			get { return color; }
			set { color = value; }
		}
		private int wheelCount;

		public int WheelCount
		{
			get { return wheelCount; }
			set { wheelCount = Math.Max(0,value); }
		}


		public Vehicle(string regNumb, string color, int wheelCount)
		{
			RegNumb = regNumb;
			Color = color;
			WheelCount = wheelCount;
		}
		public virtual string StringifyOutput() 
		{
			string vehicleInfo = $" - {RegNumb}, {Color}, {WheelCount} wheels";
			return vehicleInfo;
		}

	}
}
