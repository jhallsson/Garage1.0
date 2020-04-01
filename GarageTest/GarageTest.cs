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
        /*[TestMethod]
        public void AddVehicle_VehicleCount1()
        {
            var garageHand = new GarageHandler();
            var vehicle = new Vehicle("ABC123", "black", 4);
            
            int expected = 1;
            int actual = garageHand.Park(vehicle, garageHand.CreateGarage(3));

            Assert.AreEqual(actual, expected);
        }*/
        [TestMethod]
        public void AddVehicle_VehicleAddedTrue()
        {
            var garageHand = new GarageHandler();
            var vehicle = new Vehicle("ABC123", "black", 4);

            //bool expected = true;
            bool actual = garageHand.Park(vehicle, garageHand.CreateGarage(3));

            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void AddTwoVehicles_ReturnTrue_Count2()
        {
            var garageHand = new GarageHandler();
            var garage = garageHand.CreateGarage(3);
            var vehicle1 = new Vehicle("ABC123", "black", 4);
            var vehicle2 = new Vehicle("DEF456", "black", 8);

            int expected = 2;
            bool actual = garageHand.Park(vehicle1, garage);
            bool actual2 = garageHand.Park(vehicle2, garage);
            int count = garage.Vehicles.Count(v => v is Vehicle);

            Assert.IsTrue(actual);
            Assert.IsTrue(actual2);
            Assert.AreEqual(expected, count);

        }
        [TestMethod]
        public void RemoveVehicle_ReturnTrue()
        {
            var garageHand = new GarageHandler();
            var garage = garageHand.CreateGarage(3);
            var vehicle1 = new Vehicle("ABC123", "black", 4);
            var vehicle2 = new Vehicle("DEF456", "black", 8);

            string regNr = "ABC1230";

            bool actual = garageHand.Leave(regNr, garage);

            Assert.IsTrue(actual);
        }
    }
}
