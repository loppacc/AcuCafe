using AcuCafe.Drinks;

namespace AcuCafe
{
    //I belive a good resource to use when determining design pattern is the following:
    // https://github.com/kamranahmedse/design-patterns-for-humans
    public class DrinkFactory : IDrinkFactory
    {
        public Drink GetDrink(string type)
        {
            switch (type)
            {
                case "Expresso":
                    return new Expresso();
                case "HotTea":
                    return new Tea();
                case "IceTea":
                    return new IceTea();
            }
            return null;
        }
    }
}
