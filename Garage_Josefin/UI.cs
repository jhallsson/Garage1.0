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
            
            Console.WriteLine("Welcome to the Garage App! Start by creating a garage.\nCapacity: ");
            int.TryParse(Console.ReadLine(), out int capacity);
            GarageHandler handler = new GarageHandler(capacity);
            
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
                    "\n 6. Search with properties" + //ToDo: samma eller inte?
                    "\n 0. Close App");

                char input = Console.ReadLine()[0];

                switch (input)
                {
                    case '1': 
                        
                        string regNr = GetInput("Reg. Number: ");//ToDo: flytta? 
                        string color = GetInput("Color: ");
                        int.TryParse(GetInput("Number of wheels: "),out int wheels);
                        var vehicle = handler.CreateVehicle(regNr, color, wheels);
                        handler.Park(vehicle);
                        //message success/!
                        Console.WriteLine($"Vehicle {vehicle.RegNumb} parked");
                        break;
                    case '2':
                        var vehicleLeaving = handler.Leave("ABC123");
                        Console.WriteLine($"Vehicle {vehicleLeaving.RegNumb} left");
                        break;
                    /*case '3':
                        Console.WriteLine(handler.ListVehicles());
                        break;
                    case '4':
                        Console.WriteLine(handler.ListVehicleTypes());
                        break;
                    case '5':
                        Console.WriteLine(handler.Search("ABC123"));
                        break;
                    case '0':
                        Console.WriteLine("Thank You for Using the Garage App! Good Bye!");
                        running = false;
                        break;*/
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

            } while (running);
        }

        private string GetInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return "---"; //ToDo: error message
            }
            else
            {
                return input;   //ToDo: "0" ful lösning för tryparse? eller bättre än null?
            }
        }

        public static void Print(string info)
        {
            Console.WriteLine(info);
        }
    }
}
