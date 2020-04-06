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
            
            Print("Welcome to the Garage App! Start by creating a garage.\n");
            GarageHandler handler = new GarageHandler(); //anropar creategarage, frågar om kapacitet

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
                
                
                char input = GetInput("")[0];

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
                        bool vehicleleft = handler.Leave(leavingVehicle); 
                        if (vehicleleft)
                            Print($"Vehicle {leavingVehicle} left");
                        else
                            Print("Vehicle could not leave"); //ToDo: felmeddelanden
                        break;
                    case '3':
                        handler.ListVehicles();
                        break;
                    case '4':
                        string type = GetInput("Wich Type of Vehicle?"); //ToDo: Finns i listan/finns inte i listan
                        bool validType = TryTypeInput(type); //ToDo: flytta till ListVehicleTypes
                        if (validType)
                        {
                            //Print($"All {type}s in the Garage: ");
                            handler.ListVehicleTypes(type);

                        }
                        else
                            Print("Invalid input. Try Again");
                        break;
                    case '5':
                        string searched = GetInput("Type in Reg. Number: ");
                        if (!handler.RegNumberExists(searched))
                            Print($"{searched.ToUpper()} is not in the Garage");
                        break;
                    case '6':
                        var list = handler.SearchProperty();
                        
                        if (list.Count > 0)
                        {
                            Print("Matching Vehicles: ");
                            foreach (var vehicle in list)
                            {
                                Print($" - {handler.StringifyOutput(vehicle)}");
                            }
                        }
                        else Print("No Match!");
                        /*fråga(vilka /)vilket property(/ max fyra ? )typ, color x, wheels x

                        
                        
                        Söka efter fordon utifrån en  egenskap eller flera.
                        Till exempel alla svarta fordonmed fyra hjul.
                        Eller enbart alla motorcyklar som är rosa och har 3 hjul

                        (
                        antingen color brown eller 1.brown 2.brown
                        eller hitta om det finns något property som heter samma som ex "brown"
                        if vehicles.color contains*/
                        break; 
                    case '0':
                        Print("Thank You for Using the Garage App! Good Bye!");
                        running = false;
                        break;
                    default:
                        Print("Something went wrong. Please try again.");
                        break;
                }

            } while (running);
        }
        
        public string GetInput(string message, string typeOfInput) //ToDo: fel att använda objekt? string, vehicle, int...
        {
            bool wrongInput = true;
            string input;
            do                  //ToDo: provkör
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToUpper();   //ToDo: vart ska jag lägga toupper
                if (string.IsNullOrEmpty(input))
                {
                    //ToDo: error message
                    Print("\nInput can not be blank. Try Again!");
                }
                else
                {
                    bool accepted = false;
                    switch (typeOfInput)
                    {
                        case "Type":
                            accepted = TryTypeInput(input);
                            break;
                        case "RegNr":
                            accepted = TryRegNumbInput(input);
                            break;
                        case "Int":
                            accepted = TryParseInput(input);
                            break;
                    }
                    if (accepted)
                        wrongInput = false;
                    else
                        Print("Invalid input. Try Again!");//ToDo: byt
                }
            } while (wrongInput);
            return input;   //ToDo: "0" ful lösning för tryparse? eller bättre än null?

        }
        public string GetInput(string message)
        {
            string input;
            Console.WriteLine(message);
            input = Console.ReadLine();
            return input;   //ToDo: "0" ful lösning för tryparse? eller bättre än null?
            /*bool wrongInput = true;
            do
            {
                if (string.IsNullOrEmpty(input))//ta bort denna null och använd den andra för viktiga?
                {
                    Print("Invalid Input. Try Again!"); //ToDo: error message
                }
                else
                {
                wrongInput = false;
                }
            } while (wrongInput);*/
        }
        /*public string GetInput(string message) //ToDo: fel att använda objekt? string, vehicle, int...
        {
            
            string input;
            bool wrongInput = true;
            do
            {
            Console.WriteLine(message);
            input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))//ta bort denna null och använd den andra för viktiga?
                {
                    Print("Invalid Input. Try Again!"); //ToDo: error message
                }
                else
                {
                    wrongInput = false;
                }
            } while (wrongInput);
            
            return input;   //ToDo: "0" ful lösning för tryparse? eller bättre än null?

        }*/

        private bool TryParseInput(string input)
        {
            bool returnValue = false;
            if (!int.TryParse(input, out int result))
            {
                Print("Must be a number, try again!");
            }
            else
            {
                returnValue = true;
            }
            return returnValue;
        }
        

        public bool TryRegNumbInput(string input)
        {
            var handler = new GarageHandler();
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
            if(!returnValue)
                Print("Invalid Reg. Number. Must be of type 'AAA111'");
            return returnValue;
        }

        public bool TryTypeInput(string input)
        {
            bool returnValue = false;
            List<string> typeList = new List<string>() { "airplane", "boat", "bus", "car", "motorcycle" };

            returnValue = typeList.Contains(input.ToLower());
            if (!returnValue)
                Print("Must be a valid type. Try Again");
            return returnValue;

        }
        public void Print(string info)
        {
            Console.WriteLine(info);
        }
    }
}

