﻿using System;
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
            
            //Print("Garage succesfully built!");
            
            do
            {
              Print("\nNavigate through the menu by selecting a number." +
                    "\n 1. Park" +
                    "\n 2. Let Vehicle leave" + 
                    "\n 3. List" +
                    "\n 4. List by Type" +
                    "\n 5. Search" +
                    "\n 6. Search with properties" +
                    "\n 0. Close App");
                
                char input = GetInput("","null")[0];
                switch (input)
                {
                    case '1':
                        if (handler.GarageIsFull())
                           Print("The Garage is full! One or " +
                               "more Vehicles need to leave");
                        else
                        {
                            string regNr = GetInput("Reg. Number: ", "RegNr");
                            if (!handler.RegNumberExists(regNr))
                            {
                                var vehicle = handler.CreateVehicle(regNr); //ToDo: anropas från park istället? -> kan inte göra färdiga värden utan input då (fullgarage)
                                bool parked = handler.Park(vehicle); //Todo: global variabel - funkar inte
                                if (parked)
                                    Print($"Vehicle {vehicle.RegNumb} parked");
                                else
                                    Print("Could not park");
                            }
                            else
                                Print($"A Vehicle with reg. number {regNr} already " +
                                    $"exists. Should i call the cops on you?"); 
                        }
                        break;
                    case '2':
                        string leavingVehicle = GetInput("Type in the Reg. Number for the leaving vehicle: ", "RegNr");
                        bool vehicleleft = handler.Leave(leavingVehicle); 
                        if (vehicleleft)
                            Print($"Vehicle {leavingVehicle} left");
                        else
                            Print("Vehicle could not leave"); 
                        break;
                    case '3':
                        handler.ListVehicles();
                        break;
                    case '4':
                        string type = GetInput("Wich Type of Vehicle?","Type"); 
                        var typeList = handler.ListVehicleTypes(type);
                        if (typeList.Count > 0)
                        {
                            Print($"Every {type} in the Garage: ");
                            typeList.ForEach(v => Print($"{handler.StringifyOutput(v)}"));
                        }
                        else
                            Print($"There is no {type} in the Garage yet.");
                            break;
                    case '5':
                        string searched = GetInput("Type in Reg. Number: ","RegNr");
                        if (!handler.RegNumberExists(searched))
                            Print($"{searched.ToUpper()} is not in the Garage");
                        else
                            Print(handler.Search(searched));
                        break;
                    case '6':
                        var list = handler.SearchProperty();
                        
                        if (list.Count > 0)
                        {
                            Print("Matching Vehicles: ");
                            list.ForEach(v=> Print($"{handler.StringifyOutput(v)}")); 
                        }
                        else Print("No Match!");
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
        public string GetInput(string message, string typeOfInput)
        {
            bool wrongInput = true;
            string input;
            do  
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToLower();  //så att alla värden i grunden är "snygga"
                if (string.IsNullOrEmpty(input))
                    Print("\nInput can not be blank. Try Again!");//ToDo: error message
                else
                {
                    bool accepted = false;
                    switch (typeOfInput)
                    {
                        case "Type":
                            accepted = TryTypeInput(input);
                            break;
                        case "RegNr":
                            accepted = TryRegNumbInput(input.ToUpper()); //
                            break;
                        case "Int":
                            accepted = TryParseInput(input);
                            break;
                        case "Double":
                            accepted = TryParseToDoubleInput(input);
                            break;
                        default: accepted = true; //för alla andra inputs?
                            break;
                    }
                    if (accepted)
                        wrongInput = false;
                }
            } while (wrongInput);
            return input;   
        }
        public string GetInput(string message)
        {
            string input;
            Console.WriteLine(message);
            input = Console.ReadLine();
            return input; 
        }
        private bool TryParseInput(string input)
        {
            bool returnValue = false;
            if (!int.TryParse(input, out int result))
            {
                Print("Must be a integer number, try again!");
            }
            else
            {
                returnValue = true;
            }
            return returnValue;
        }
        private bool TryParseToDoubleInput(string input)
        {
            bool returnValue = false;
            if (!double.TryParse(input, out double result))
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
            bool returnValue = false; //ToDo: kolla om det redan finns - just nu i menu - ok?
            if (input.Length == 6 /*&& !exists*/)
            {
                for (int i = 0; i < 3; i++)     //ToDo: använd linq? hittar inget bättre
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

