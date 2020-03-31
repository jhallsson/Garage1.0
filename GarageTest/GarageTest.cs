using Microsoft.VisualStudio.TestTools.UnitTesting;
using Garage_Josefin;

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

            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void AddVehicle_VehicleCount1()
        {
            var garage = new Garage<Vehicle>(3);
            var vehicle = new Vehicle("ABC123", "black", 4);
            
            int expected = 1;
            int actual = garage.AddVehicle(vehicle);

            Assert.AreEqual(actual, expected);



        }
    }
}
