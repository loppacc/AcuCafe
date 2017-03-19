using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Ingredients;
using Moq;
using NUnit.Framework;

namespace AcuCafe.Tests
{
    [TestFixture]
    public class BaristaTests
    {
        private Mock<IOutputWriter> _outputWriter;

        [SetUp]
        public void Setup()
        {
            _outputWriter = new Mock<IOutputWriter>();
        }

        [Test]
        public void OrderDrink_ExpressoWithChocolateToppin2g_WillWriteExpectedMessage()
        {
            var expectedMessage = "We are preparing the following drink for you: Expresso with choclate topping, without sugar, without milk.";

            var message = GetBarista().Prepare(new Expresso {Ingredients = new List<IIngredient> {new ChocolateTopping() } });

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void OrderDrink_ExpressoWithChocolateTopping_WillWriteExpectedMessage()
        {
            var expectedMessage = "We are preparing the following drink for you: Expresso with choclate topping, with milk, with sugar.";

            var message = GetBarista().Prepare(new Expresso { Ingredients = new List<IIngredient> { new ChocolateTopping(), new Milk(), new Sugar()} });

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void OrderDrink_IceTeaWithSugar_WillWriteExpectedMessage()
        {
            var expectedMessage = "We are preparing the following drink for you: Ice tea with sugar.";

            var message = GetBarista().Prepare(new IceTea { Ingredients = new List<IIngredient> { new Sugar() } });

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void OrderDrink_IceTea_WillWriteExpectedMessage()
        {
            var expectedMessage = "We are preparing the following drink for you: Ice tea without sugar.";

            var message = GetBarista().Prepare(new IceTea { Ingredients = new List<IIngredient>()});

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        private Barista GetBarista()
        {
            return new Barista(_outputWriter.Object);
        }
    }
}
