using System;
using System.Collections.Generic;
using AcuCafe.Drinks;
using AcuCafe.Ingredients;

namespace AcuCafe
{
    public class AcuCafe
    {
        private readonly ILogger _logger;
        private readonly IDrinkFactory _drinkFactory;
        private readonly IBarista _barista;

        public AcuCafe(ILogger logger, IDrinkFactory drinkFactory, IBarista barista)
        {
            _logger = logger;
            _drinkFactory = drinkFactory;
            _barista = barista;
        }

        //Removed static property, to be able add dependency injection. 
        //Changing the signature of AcuCafe as it was not defined it could be done or not and it improves code quality (Enabling of DI).
        public Drink OrderDrink(string type, IEnumerable<IIngredient> ingredients)
        {
            var drink = _drinkFactory.GetDrink(type);
            try
            {
                drink.AddIngredients(ingredients);
                var message = _barista.Prepare(drink);
                _barista.NotifyCustomer(message);
            }
            catch (Exception ex)
            {
                _barista.NotifyCustomerAboutIssue();
                _logger.Handle(ex.ToString());
            }
            return drink;
        }
    }
}