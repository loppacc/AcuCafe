namespace AcuCafe.Ingredients
{
    public class ChocolateTopping : IIngredient
    {
        public double Cost => 0.5;
        public override string ToString()
        {
            return "choclate topping";
        }
    }
}
