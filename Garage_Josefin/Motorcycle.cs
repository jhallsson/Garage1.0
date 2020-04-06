using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
	class Motorcycle : Vehicle
	{
		private double topSpeed;

		public double TopSpeed
		{
			get { return topSpeed; }
			set { topSpeed = value; }
		}

		public Motorcycle(double topSpeed, string regNumb, string color, int wheelCount)
			: base(regNumb, color, wheelCount)
		{
			TopSpeed = topSpeed;
		}

		public override string StringifyOutput()//ToDo: använd .tostring istället?
		{
			string vehicleInfo = $"{base.StringifyOutput()}, top speed: {TopSpeed} km/h.";
			return vehicleInfo;
		}
	}
}
