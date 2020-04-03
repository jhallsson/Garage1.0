using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_Josefin
{
    public class UI
    {
        GarageHandler handler;
        public void Menu()
        {
            bool running = true;

            Print("Welcome to the Garage App! Start by creating a garage.\nCapacity: ");
            int.TryParse(Console.ReadLine(), out int capacity);
            handler = new GarageHandler(capacity);

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
                        if (handler.GarageIsFull())
                        {
                            Print("The Garage is Full! One or More Vehicles Need to Leave");
                        }
                        else
                        {
                            var vehicle = handler.CreateVehicle();
                            bool parked = handler.Park(vehicle); //Todo: global variabel?

                            if (parked)
                                Print($"Vehicle {vehicle.RegNumb} parked");
                            else
                                Print("Something went wrong"); //ToDo: samla
                        }
                        break;
                    case '2':
                        string leavingVehicle = GetInput("Type in the Reg. Number for the leaving vehicle: ");
                        bool left = handler.Leave(leavingVehicle); //ToDo bool?
                        if (left)
                            Print($"Vehicle {leavingVehicle} left");
                        else
                            Print("Vehicle could not leave"); //ToDo: felmeddelanden
                        break;
                    case '3':
                        handler.ListVehicles();
                        break;
                    case '4':
                        string type = GetInput("Wich Type of Vehicle?"); //ToDo: Finns i listan/finns inte i listan
                        bool validType = TryTypeInput(type);
                        if (validType)
                        {
                            //Print($"All {type}s in the Garage: ");
                            handler.ListVehicleTypes(type);

                        }
                        else
                            Print("Unvalid input. Try Again");

                        break;
                    case '5':
                        string searched = GetInput("Type in Reg. Number: ");
                        if (!handler.RegNumberExists(searched))
                            Print($"{searched.ToUpper()} is not in the Garage");

                        break;
                    case '0':
                        Print("Thank You for Using the Garage App! Good Bye!");
                        running = false;
                        break;
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
            do                  //ToDo: provkör
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToUpper();//ToDo: vart ska jag lägga toupper
                if (string.IsNullOrEmpty(input))
                {
                    //ToDo: error message
                    Print("\nUnvalid Input. Try Again!");
                }
                else
                {
                    bool accepted = false;
                    if (typeOfInput == "Type")
                        accepted = TryTypeInput(input);
                    else if (typeOfInput == "RegNr")
                        accepted = TryRegNumbInput(input);
                    if (accepted)
                        wrongInput = false;
                    else
                        Print("Invalid input. Try Again!");//ToDo: byt
                }
            } while (wrongInput);
            return input;   //ToDo: "0" ful lösning för tryparse? eller bättre än null?

        }

        public bool TryRegNumbInput(string input)
        {
            bool returnValue = false; //ToDo: kolla om det redan finns
            bool exist = handler.RegNumberExists(input);
            if (input.Length == 6 && !exist)
            {
                for (int i = 0; i < 3; i++)     //ToDo: använd linq
                {
                    if (char.IsLetter(input[i]))
                        returnValue = true;
                }
                for (int i = 3; i < 6; i++)
                {
                    if (char.IsDigit(input[i]))
                        returnValue = true;
                }
            }
            return returnValue;
        }

        private bool TryTypeInput(string input)
        {
            bool returnValue = false;
            List<string> typeList = new List<string>() { "airplane", "boat", "bus", "car", "motorcycle" };

            returnValue = typeList.Contains(input);

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
