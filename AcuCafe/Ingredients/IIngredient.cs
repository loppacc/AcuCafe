namespace AcuCafe.Ingredients
{
    public interface IIngredient
    {
        double Cost { get; }
        string ToString();
    }
}