using AcuCafe.Drinks;

namespace AcuCafe
{
    public class Barista : IBarista
    {
        private readonly IOutputWriter _outputWriter;

        public Barista(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        public string Prepare(Drink drink)
        {
            if (!drink.IsValid())
            {
                return "We are unable to prepare your drink.";
            }

            var message = "We are preparing the following drink for you: " + drink.Description;

            foreach (var ingredient in drink.Ingredients)
            {
                message += " with " + ingredient + ",";
            }

            foreach (var excludedIngredient in drink.GetExcludedIngredients())
            {
                message += " without " + excludedIngredient + ",";
            }

            message = message.Substring(0, message.Length - 1);
            message += ".";

            return message;
        }

        public void NotifyCustomer(string message)
        {
            _outputWriter.WriteLine(message);
        }

        public void NotifyCustomerAboutIssue()
        {
            _outputWriter.WriteLine("We are unable to prepare your drink.");
        }
    }
}
