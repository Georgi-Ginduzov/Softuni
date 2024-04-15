using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        /*[TestCase(50, 3)]
        [TestCase(20, 5)]
        public void ConstructorShouldInitializeAllValues(int waterCapacity, int buttonsCount)
        {
            // Arrange
            CoffeeMat coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);

            // Assert
            Assert.AreEqual(coffeeMat.WaterCapacity, waterCapacity);
            Assert.AreEqual(coffeeMat.ButtonsCount, buttonsCount);
            Assert.AreEqual(coffeeMat.Income, 0);
        }*/

        private CoffeeMat coffeeMat;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(1000, 5);
        }

        [Test]
        public void AddDrink_ShouldReturnTrue_WhenDrinkIsAddedSuccessfully()
        {
            var result = coffeeMat.AddDrink("Espresso", 1.5);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddDrink_ShouldReturnFalse_WhenDrinkAlreadyExists()
        {
            coffeeMat.AddDrink("Espresso", 1.5);
            var result = coffeeMat.AddDrink("Espresso", 1.5);
            Assert.IsFalse(result);
        }

        [Test]
        public void BuyDrink_ShouldReturnMessage_WhenDrinkIsNotAvailable()
        {
            coffeeMat.FillWaterTank();
            var result = coffeeMat.BuyDrink("Espresso");
            
            Assert.AreEqual("Espresso is not available!", result);
        }

        [Test]
        public void BuyDrink_ShouldReturnBill_WhenDrinkIsAvailable()
        {
            coffeeMat.AddDrink("Espresso", 1.5);
            coffeeMat.FillWaterTank();
            var result = coffeeMat.BuyDrink("Espresso");
            Assert.AreEqual("Your bill is 1.50$", result);
        }




    }    
}