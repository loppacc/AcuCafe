using System;
using System.Collections.Generic;
using System.Linq;
using AcuCafe.Ingredients;

namespace AcuCafe.Drinks
{
    public abstract class Drink
    {
        public IEnumerable<IIngredient> Ingredients;
        public abstract string Description { get; }
        protected abstract IEnumerable<IIngredient> DefaultIngredients { get; }

        public abstract double Cost();

        public void AddIngredients(IEnumerable<IIngredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public IEnumerable<IIngredient> GetExcludedIngredients()
        {
            return
                DefaultIngredients.Where(
                    defaultIngredient =>
                        !Ingredients.Select(ingredient => ingredient.ToString()).Contains(defaultIngredient.ToString()));
        }

        public bool IsValid()
        {
            if (Ingredients.Any(IsInvalidIngredient))
            {
                return false;
            }
            return true;
        }

        private bool IsInvalidIngredient(IIngredient ingredient)
        {
            return !DefaultIngredients.Select(i => i.ToString()).Contains(ingredient.ToString());
        }
    }
}
