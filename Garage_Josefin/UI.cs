using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    class UI
    {
        public void Menu()
        {
            bool running = true;
            GarageHandler handler = new GarageHandler();
            do
            {
                Console.WriteLine("Welcome to the Garage App! Start by creating a garage.\nCapacity: ");
                int.TryParse(Console.ReadLine(), out int capacity);
                handler.CreateGarage(capacity);
                //ToDo: check input, check success
                Console.WriteLine("Garage succesfully built!" +
                    "\nNavigate through the menu by selecting a number." +
                    "\n1. Park a vehicle" +
                    "\n2. Let a vehicle leave" +
                    "\n3. List all vehicles in garage" +
                    "\n4. List all vehicles of the same type" +
                    "\n5. Search for a vehicle" +
                    "\n0. Close down the Garage App");
                        
                char input = ' ';
                switch (input)
                {
                    case '1': 
                    case '0': 
                        running = false;
                        break;
                    default:
                        break;
                }

            } while (running);
        }
    }
}
