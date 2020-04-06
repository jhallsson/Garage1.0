using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage_Josefin;
using System.Linq;

namespace GarageTest
{
    [TestClass]
    public class GarageTest
    {
        //1.Arrange​ här sätter ni upp det som ska testas, instansierar objekt och inputs
        //2.Act​ här anropar ni metoden som ska testas
        //3.Assert​ här kontrollerar ni att ni fått det förväntade resultatet
        //[MethodName_StateUnderTest_ExpectedBehavior]
        [TestMethod]
        public void CreateGarage_SetCapacity_NewGarage()
        {
            var garage = new Garage<Vehicle>(2);
            int expected = 2;
            int actual = garage.GarageCapacity;

            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void GetPropertyVehicles_ReturnCount()
        {
            var garage = new Garage<Vehicle>(5);
            int expected = 5;
            int actual = garage.Vehicles.Length;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CreateGarage_NegativeCapacity_ReturnOne()
        {
            var garage = new Garage<Vehicle>(-2);
            int expected = 1;
            int actual = garage.GarageCapacity;
            Assert.AreEqual(expected, actual);
        }
        /*[TestMethod]
        public void AddVehicle_VehicleCount1()
        {
            var garageHand = new GarageHandler();
            var vehicle = new Vehicle("ABC123", "black", 4);
            
            int expected = 1;
            int actual = garageHand.Park(vehicle, garageHand.CreateGarage(3));

            Assert.AreEqual(actual, expected);
        }*/
        /*[TestMethod]
        public void AddVehicle_VehicleAddedTrue()
        {
            var garageHand = new GarageHandler(4);//ToDo: anpassa, funkade bra vid skapandet av appen
            var vehicle = new Vehicle("ABC123", "black", 4);

            //bool expected = true;
            bool actual = garageHand.Park(vehicle);

            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void AddTwoVehicles_ReturnTrue_Count2()
        {
            var garageHand = new GarageHandler(3);
            var vehicle1 =garageHand.CreateVehicle("ABC123", "black", 4);
            var vehicle2 = garageHand.CreateVehicle("DEF456", "black", 8);

            int expected = 2;
            garageHand.Park(vehicle1);
            garageHand.Park(vehicle2);

            int actual=garageHand.CountVehicles();
            //int count = garageHand.Vehicles.Count(v => v is Vehicle);

           Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void RemoveVehicle_ReturnLeavingVehicle()
        {
            var garageHand = new GarageHandler(3);
            var vehicle1 = garageHand.CreateVehicle("ABC123", "black", 4); //instansera själv eller använda metod?
            var vehicle2 = garageHand.CreateVehicle("DEF456", "black", 8);
            garageHand.Park(vehicle1);
            garageHand.Park(vehicle2);


           
            string regNr = "abc123";
            bool expected = true;
            
            bool actual = garageHand.Leave(regNr); //Vehicle

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FixRegNumber_ReturnUpperCase()
        {
            var garageHand = new GarageHandler(3);
            var vehicle = garageHand.CreateVehicle("abc123", "black", 4);
            garageHand.Park(vehicle);
            string expected = $"Vehicle: ABC123, color: black, 4 wheels.";
        
            string actual = garageHand.Search("abc123");
            Assert.AreEqual(expected, actual);
        }*/
        [TestMethod]
        public void ListVehicles_WithFullCapacity_ReturnAllIVehicles()
        {
            /*var garageHand = new GarageHandler();
            var vehicle = garageHand.CreateVehicle("ABC123");
            var vehicle2 = garageHand.CreateVehicle("DEF456");

            garageHand.Park(vehicle);
            garageHand.Park(vehicle2);

            garageHand.ListVehicles();*/

            //ToDo: finish

        }
    }
}
