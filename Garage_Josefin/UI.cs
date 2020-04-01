using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    public class UI
    {
        public void Menu()
        {
            bool running = true;
            GarageHandler handler = new GarageHandler();
            Console.WriteLine("Welcome to the Garage App! Start by creating a garage.\nCapacity: ");
            int.TryParse(Console.ReadLine(), out int capacity);
            var garage= handler.CreateGarage(capacity);
            //ToDo: check input, check success
            Console.WriteLine("Garage succesfully built!");
            do
            {
                
                Console.WriteLine("\nNavigate through the menu by selecting a number." +
                    "\n 1. Park" +
                    "\n 2. Let Vehicle leave" + //dismiss??
                    "\n 3. List" +
                    "\n 4. List by Type" +
                    "\n 5. Search" +
                    "\n 0. Close App");

                char input = Console.ReadLine()[0];

                switch (input)
                {
                    case '1': //ToDo: fkytta? byt ut hårdkod
                        var vehicle = handler.CreateVehicle("ABC123", "green", 4);
                        handler.Park(vehicle, garage);
                        Console.WriteLine($"Vehicle {vehicle.RegNumb} parked");
                        break;
                    case '2':
                        var vehicleLeaving = handler.Leave("ABC123", garage);
                        Console.WriteLine($"Vehicle {vehicleLeaving.RegNumb} left");
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
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
