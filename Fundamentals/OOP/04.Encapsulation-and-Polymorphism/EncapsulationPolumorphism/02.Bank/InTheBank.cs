using System;
using System.Runtime.CompilerServices;
using _02.Bank.Accounts;
using _02.Bank.Customers;
using _02.Bank.Enums;

namespace _02.Bank
{
    class InTheBank
    {
        static void Main()
        {
            var individual = new Individual("Dimitar", "Dimov", 44, "Pencho Slaveikov", 
                City.Sofia, Country.Bulgaria, 120000);
            
            var company = new Company("Boris Karadjov 35", City.Plovdiv, Country.Bulgaria, 10300000000, 203);

            var deposit = new Deposit(individual, 1200, 4);

            Console.WriteLine("Withdraw: " + deposit.Withdraw(12));
            Console.WriteLine("Interest: " + deposit.CalculateInterest(12) + " lv.");

            var loan = new Loan(company, 300000, 3);

            Console.WriteLine("Deposit: " + loan.Deposite(130000));
            Console.WriteLine("Interest: " + loan.CalculateInterest(16) + " lv.");

            var mortgageInd = new Mortgage(individual, 1000, 6);

            Console.WriteLine("Deposit: " + mortgageInd.Deposite(300));
            Console.WriteLine("Interest: " + mortgageInd.CalculateInterest(24) + " lv.");
            Console.WriteLine("Interest (6 mnt): " + mortgageInd.CalculateInterest(6) + " lv.");

            var mortgageComp = new Mortgage(company, 10000, 6);
            Console.WriteLine("Interest company (6 mnt): " + mortgageComp.CalculateInterest(6) + " lv.");
        }
    }
}
