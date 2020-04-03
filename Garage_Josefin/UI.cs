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
            
            Print("Welcome to the Garage App! Start by creating a garage.\nCapacity: ");
            int.TryParse(Console.ReadLine(), out int capacity);
            GarageHandler handler = new GarageHandler(capacity);
            
            //ToDo: check input, check success
            Print("Garage succesfully built!");
            do
            {
                
                Print("\nNavigate through the menu by selecting a number." +
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

                        var vehicle = handler.CreateVehicle();

                        bool success = handler.Park(vehicle); //Todo: global variabel?
                        if (success)
                            Print($"Vehicle {vehicle.RegNumb} parked");
                        else
                            Print("Something went wrong"); //ToDo: samla
                        break;
                    case '2':
                        string leavingVehicle = GetInput("Type in the Reg. Number for the leaving vehicle: ");
                        success = handler.Leave(leavingVehicle); //ToDo bool?
                        if (success)
                            Print($"Vehicle {leavingVehicle} left");
                        else
                            Print("Vehicle could not leave"); //ToDo: felmeddelanden
                        break;
                    case '3':
                        handler.ListVehicles();
                        break;
                    case '4':
                        string type = GetInput("Wich Type of Vehicle?"); //ToDo: Finns i listan/finns inte i listan
                        //string -> typ
                        handler.ListVehicleTypes(type);
                        //if vehicle is typ
                        //print
                        Print(type);                
                        
                        break;
                    /*case '5':
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

        public string GetInput(string message, string typeOfInput) //ToDo: fel att använda objekt? string, vehicle, int...
        {
            //ToDo: skicka med typ av input och kör rätt metod efter nullcheck?
            //do while?
            bool wrongInput = true;
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    switch (input)
                    {
                        case "type":
                            bool accepted= TryTypeInput(input);
                            break;
                        case "regNr":
                            break;
                        default:
                            break;
                    }
                    //case typeOfInput = "type"

                    //if input!=listItem
                    //print(unvalid)
                    Print("Unvalid Input. Try Again!"); //ToDo: error message
                }
                else
                {
                    wrongInput = false;
                }
            } while (wrongInput);
            return input;   //ToDo: "0" ful lösning för tryparse? eller bättre än null?

        }

        private bool TryTypeInput(string input)
        {
            bool returnValue = false;
            List<string> typeList = new List<string>() { "airplane", "boat", "bus", "car", "motorcycle" };
            
            foreach (string type in typeList)
            {
                if (input == type)
                    returnValue= true;
                else
                    returnValue= false;
            }
            return returnValue;

        }

        public string GetInput(string message) //ToDo: fel att använda objekt? string, vehicle, int...
        {
            //ToDo: skicka med typ av input och kör rätt metod efter nullcheck?
            //do while?
            bool wrongInput = true;
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Print("Unvalid Input. Try Again!"); //ToDo: error message
                }
                else
                {
                    wrongInput = false;
                }
            } while (wrongInput);
            return input;   //ToDo: "0" ful lösning för tryparse? eller bättre än null?

        }
        public void Print(string info) //måste vara static?
        {
            Console.WriteLine(info);
        }
        
    }
}
