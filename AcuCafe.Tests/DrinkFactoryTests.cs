using AcuCafe.Drinks;
using NUnit.Framework;

namespace AcuCafe.Tests
{
    [TestFixture]
    public class DrinkFactoryTests
    {
        [Test]
        public void OrderDrink_TypeExpresso_WillReturnExpresso()
        {
            var drink = GetDrinkFactory().GetDrink("Expresso");

            Assert.IsTrue(drink is Expresso);
        }

        [Test]
        public void GetDrink_TypeExpresso_WillReturnExpresso()
        {
            var drink = GetDrinkFactory().GetDrink("Expresso");

            Assert.IsTrue(drink is Expresso);
        }

        [Test]
        public void GetDrink_TypeTea_WillReturnTea()
        {
            var drink = GetDrinkFactory().GetDrink("HotTea");

            Assert.IsTrue(drink is Tea);
        }

        [Test]
        public void GetDrink_TypeIceTea_WillReturnIceTea()
        {
            var drink = GetDrinkFactory().GetDrink("IceTea");

            Assert.IsTrue(drink is IceTea);
        }

        [Test]
        public void GetDrink_MissingType_WillReturnNull()
        {
            var drink = GetDrinkFactory().GetDrink(null);

            Assert.IsNull(drink);
        }

        private static DrinkFactory GetDrinkFactory()
        {
            return new DrinkFactory();
        }
    }
}
