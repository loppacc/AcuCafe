namespace AcuCafe.Ingredients
{
    public class Sugar : IIngredient
    {
        public double Cost => 0.5;
        public override string ToString()
        {
            return "sugar";
        }
    }
}
