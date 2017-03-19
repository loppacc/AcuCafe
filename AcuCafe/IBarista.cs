using AcuCafe.Drinks;

namespace AcuCafe
{
    public interface IBarista
    {
        string Prepare(Drink drink);
        void NotifyCustomer(string message);
        void NotifyCustomerAboutIssue();
    }
}