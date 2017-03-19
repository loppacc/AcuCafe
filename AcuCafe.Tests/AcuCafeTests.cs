using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Ingredients;
using Moq;
using NUnit.Framework;

namespace AcuCafe.Tests
{
    [TestFixture]
    public class AcuCafeTests
    {
        private Mock<ILogger> _fileLogger;
        private Mock<IDrinkFactory> _drinkFactory;
        private Mock<IBarista> _barista;

        [SetUp]
        public void Setup()
        {
            _fileLogger = new Mock<ILogger>();
            _drinkFactory = new Mock<IDrinkFactory>();
            _barista = new Mock<IBarista>();
        }

        [Test]
        public void OrderDrink_NoMatchingDrink_WillCallNotfiyCustomerAboutIssue()
        {
            GetCafe().OrderDrink(null, new List<IIngredient> {new Milk()});

            _barista.Verify(barista => barista.NotifyCustomerAboutIssue(), Times.Once);
        }

        [Test]
        public void OrderDrink_NoMatchingDrink_WillCallHandle()
        {
            GetCafe().OrderDrink(null, new List<IIngredient> { new Milk() });

            _fileLogger.Verify(logger => logger.Handle(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void OrderDrink_ValidDrink_WillBeReturned()
        {
            _drinkFactory.Setup(y => y.GetDrink(It.IsAny<string>())).Returns(new IceTea());

            var drink = GetCafe().OrderDrink("IceTea", new List<IIngredient>());

            Assert.True(drink is IceTea);
        }

        [Test]
        public void OrderDrink_ValidDrink_WillCallPrepare()
        {
            _drinkFactory.Setup(y => y.GetDrink(It.IsAny<string>())).Returns(new IceTea());

            GetCafe().OrderDrink("IceTea", new List<IIngredient>());

            _barista.Verify(barista => barista.Prepare(It.IsAny<Drink>()), Times.Once);
        }

        [Test]
        public void OrderDrink_ValidDrink_WillCallNotifyCustomer()
        {
            _drinkFactory.Setup(y => y.GetDrink(It.IsAny<string>())).Returns(new IceTea());

            GetCafe().OrderDrink("IceTea", new List<IIngredient>());

            _barista.Verify(barista => barista.NotifyCustomer(It.IsAny<string>()), Times.Once);
        }

        private AcuCafe GetCafe()
        {
            return new AcuCafe(_fileLogger.Object, _drinkFactory.Object, _barista.Object);
        }
    }
}
