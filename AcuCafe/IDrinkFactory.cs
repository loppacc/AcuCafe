using AcuCafe.Drinks;

namespace AcuCafe
{
    public interface IDrinkFactory
    {
        Drink GetDrink(string type);
    }
}