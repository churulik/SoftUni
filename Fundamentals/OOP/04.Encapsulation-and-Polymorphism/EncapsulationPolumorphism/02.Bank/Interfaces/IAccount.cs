using _02.Bank.Customers;

namespace _02.Bank.Interfaces
{
    public interface IAccount
    {
        decimal CalculateInterest(int months);
        decimal Deposite(decimal sum);
    }
}