using System.Collections.Generic;
using AcuCafe.Ingredients;
using Moq;
using NUnit.Framework;

namespace AcuCafe.Tests
{
    [TestFixture]
    public class AcuCafeIntegrationTests
    {
        private Mock<IOutputWriter> _outputWriter;
        private Mock<ILogger> _fileLogger;

        [SetUp]
        public void Setup()
        {
            _outputWriter = new Mock<IOutputWriter>();
            _fileLogger = new Mock<ILogger>();
        }

        [Test]
        public void OrderDrink_IceTeaWithMilk_WillWriteExpectedMessage()
        {
            var expectedMessage = "We are unable to prepare your drink.";

            GetCafe().OrderDrink("IceTea", new List<IIngredient> {new Milk()});

            _outputWriter.Verify(writer => writer.WriteLine(expectedMessage));
        }

        [Test]
        public void OrderDrink_IceTeaWithMilk_IsInvalid()
        {
            var drink = GetCafe().OrderDrink("IceTea", new List<IIngredient> { new Milk() });

            Assert.IsFalse(drink.IsValid());
        }


        [Test]
        public void OrderDrink_ExpressoWithChocolateTopping_WillWriteExpectedMessage()
        {
            var expectedMessage = "We are preparing the following drink for you: Expresso with choclate topping, without sugar, without milk.";

            GetCafe().OrderDrink("Expresso", new List<IIngredient> { new ChocolateTopping() });

            _outputWriter.Verify(
                writer =>
                    writer.WriteLine(expectedMessage));
        }

        [Test]
        public void OrderDrink_ExpressoWithChocolateTopping_IsValid()
        {
            var drink = GetCafe().OrderDrink("Expresso", new List<IIngredient> { new ChocolateTopping() });

            Assert.IsTrue(drink.IsValid());
        }

        private AcuCafe GetCafe()
        {
            return new AcuCafe(_fileLogger.Object, new DrinkFactory(), new Barista(_outputWriter.Object));
        }
    }
}
