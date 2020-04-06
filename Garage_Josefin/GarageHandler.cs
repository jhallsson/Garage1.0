using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage_Josefin
{
    public class GarageHandler
    {
        Garage<Vehicle> garage;
        UI console = new UI();
        
        public GarageHandler()
        {
            CreateGarage();
            
            FullGarage();
        }
        private void CreateGarage()
        {
            string input = console.GetInput("Capacity: ", "Int"); //kommer inte tillbaka förrän rätt
            int.TryParse(input, out int capacity); //checkar ändå

            
            garage = new Garage<Vehicle>(capacity);
            console.Print($"Garage succesfully built with {garage.GarageCapacity} parking spaces!");
        }
        
        public Vehicle CreateVehicle(string regNr) //vilken typ??
        {
            string type = console.GetInput("Type of Vehicle: ", "Type");
            string color = console.GetInput("Color: ","null");                           //Kollar bara för null  
            int.TryParse(console.GetInput("Number of wheels: ", "Int"), out int wheels);
            switch (type)
            {
                case "airplane":
                    int seats= int.Parse(console.GetInput("Seats: ","Int"));            //ToDo: dubbelkolla parse eller inte... onödigt? vad är snyggast?
                    Vehicle airplane = new Airplane(seats, regNr, color, wheels);
                    return airplane;
                case "boat":
                    double draft = double.Parse(console.GetInput("Draft: ", "Double"));
                    Vehicle boat = new Boat(draft, regNr, color, wheels);
                    return boat;
                case "bus":
                    double.TryParse(console.GetInput("Length: ", "Double"), out double length);
                    Vehicle bus = new Bus(length, regNr, color, wheels);
                    return bus;
                case "car":
                    string brand = console.GetInput("Which Brand?", "null");
                    Vehicle car = new Car(brand, regNr, color, wheels);
                    return car;
                case "motorcycle":
                    double.TryParse(console.GetInput("Top Speed: ", "Double"), out double topSpeed);
                    Vehicle motorcycle = new Motorcycle(topSpeed, regNr, color, wheels);
                    return motorcycle;
                default:
                    console.Print("Something Went Wrong. Try Again."); //om värdena är checkade borde den inte nå default
                    Vehicle v = new Vehicle("---123","---",0);
                    return v;
                    //ToDo: bättre lösning!
            }
        }
        public bool Park(Vehicle vehicle)   
        {
            int countBefore = CountVehicles();
            
            int index = Array.FindIndex(garage.Vehicles, v=> v== null);
            garage.Vehicles[index] = vehicle;                   
            
            int countAfter = CountVehicles();
            return countAfter > countBefore;
        }
        public bool Leave(string regNr)
        {
            int countBefore = CountVehicles();
            string leaving = regNr.ToUpper();
            
            int index = Array.FindIndex(garage.Vehicles, v => v.RegNumb == leaving);
            garage.Vehicles[index] = null;

            int countAfter = CountVehicles();
            return countBefore > countAfter;
        }
        public void ListVehicles() 
        {
            var list = new List<string>();
            Array.ForEach(garage.Vehicles.Where(v => v is Vehicle).ToArray(),
                t=>console.Print(StringifyOutput(t))); //Förvirrade mig rejält där, men ville ändå prova med linq!
        }
        internal List<Vehicle> ListVehicleTypes(string type)
        {
            var list = new List<Vehicle>();
            type = type.ToLower();
            Array.ForEach(garage.Vehicles, v =>list = TypeListMaker(type));
            return list;
        }
        public string Search(string regNr)
        {
            regNr = regNr.ToUpper();
            Vehicle vehicle = garage.Vehicles?.Where(v => v?.RegNumb == regNr).FirstOrDefault();
            int index = Array.IndexOf(garage.Vehicles, vehicle);

            /*string match;
            Array.Find(garage.Vehicles.Where(v => v.RegNumb == regNr).ToArray(),t=> StringifyOutput(t));
*/
            return StringifyOutput(vehicle);
        }
        public List<Vehicle> SearchProperty()
        {
            List<Vehicle> searchList = new List<Vehicle>();
            string type = console.GetInput("Type: ").ToLower();
            string color = console.GetInput("Color: ");
            string wheelCount= console.GetInput("Wheels: ");

            searchList= !string.IsNullOrEmpty(type) ? TypeListMaker(type): garage.Vehicles.Where(v => v is Vehicle).ToList();
            searchList = !string.IsNullOrEmpty(color)? searchList.Where(v => v.Color == color).ToList(): searchList; //snyggare men ser lite fult ut med else när det inte behövs
            searchList = int.TryParse(wheelCount, out int wheels)? searchList.Where(v => v.WheelCount == wheels).ToList(): searchList;

            return searchList; 
        }

        private List<Vehicle> TypeListMaker(string type)
        {
            var list = new List<Vehicle>();
            switch (type)
            {
                case "airplane":
                    list = garage.Vehicles.Where(v => v is Airplane).ToList(); //ToDo: rätt att välja tolist?
                    break;
                case "boat":
                    list = garage.Vehicles.Where(v => v is Boat).ToList(); 
                    break;
                case "bus":
                    list = garage.Vehicles.Where(v => v is Bus).ToList();
                    break;
                case "car":
                    list = garage.Vehicles.Where(v => v is Car).ToList();
                    break;
                case "motorcycle":
                    list = garage.Vehicles.Where(v => v is Motorcycle).ToList();
                    break;
                default:
                    console.Print($"There is no such type as {type}");
                    break;
            }
            return list;
        }

        public string StringifyOutput(Vehicle vehicle) 
        {
            return vehicle.StringifyOutput();
        }
        public bool RegNumberExists(string regNumber)
        {
            return garage.Vehicles.Where(v => v is Vehicle).Any(v => v.RegNumb == regNumber);
        }
        public bool GarageIsFull()
        {
            return CountVehicles() >= garage.GarageCapacity;
        }
        private int CountVehicles()
        {
            int count = garage.Vehicles.Count(v => v is Vehicle);
            return count;
        }
        public void FullGarage() //använt för test!
        {
            Vehicle car = new Car("Volvo", "ABC123", "green", 4);     
            Vehicle car2 = new Car("Ford", "DEF456", "blue", 4);
            Vehicle boat = new Boat(3.52, "GHI789", "red", 0);
            Vehicle motorcycle = new Motorcycle(320.7, "JKL012", "red", 2);
            Vehicle airplane = new Airplane(500, "MNO345", "white", 8);
            Vehicle bus = new Bus(12.41, "PQR678", "blue", 8);

            Park(car);
            Park(car2);
            Park(boat);
            Park(motorcycle);
            Park(airplane);
            Park(bus);
        }
    }
}
