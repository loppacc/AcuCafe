using System.Collections.Generic;
using System.Linq;
using AcuCafe.Ingredients;

namespace AcuCafe.Drinks
{
    public class IceTea : Drink
    {
        protected override IEnumerable<IIngredient> DefaultIngredients => new List<IIngredient> { new Sugar()};

        public override string Description => "Ice tea";

        public override double Cost()
        {
            var cost = 1.5;
            cost += Ingredients.Sum(i => i.Cost);
            return cost;
        }
    }
}
