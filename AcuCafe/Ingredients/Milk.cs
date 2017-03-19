namespace AcuCafe.Ingredients
{
    public class Milk : IIngredient
    {
        public double Cost => 0.5;

        public override string ToString()
        {
            return "milk";
        }
    }
}
