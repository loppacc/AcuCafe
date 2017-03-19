using System.Collections.Generic;
using System.Linq;
using AcuCafe.Ingredients;

namespace AcuCafe.Drinks
{
    public class Expresso : Drink
    {
        protected override IEnumerable<IIngredient> DefaultIngredients => new List<IIngredient> { new Sugar(), new Milk(), new ChocolateTopping() };

        public override string Description => "Expresso";

        public override double Cost()
        {
            var cost = 1.8;
            cost += Ingredients.Sum(i => i.Cost);
            return cost;
        }
    }
}