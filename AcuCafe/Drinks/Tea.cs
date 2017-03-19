using System.Collections.Generic;
using System.Linq;
using AcuCafe.Ingredients;

namespace AcuCafe.Drinks
{
    public class Tea : Drink
    {
        protected override IEnumerable<IIngredient> DefaultIngredients => new List<IIngredient> {new Sugar(), new Milk()};

        public override string Description => "Hot tea";

        public override double Cost()
        {
            double cost = 1;
            cost += Ingredients.Sum(i => i.Cost);
            return cost;
        }
    }
}
