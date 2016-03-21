using System;
using System.Linq;

namespace ATM_Withdraw
{
    public class Atm
    {
        public static void Withdrawal(string cardNumber, string cardPin, decimal sum)
        {
            var context = new ATMEntities();
            
            using (var atmTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var getAccount = context.CardAccounts.First(c => c.CardNumber == cardNumber);

                    if (getAccount.CardPin == cardPin)
                    {
                        if (getAccount.CardCash >= sum && getAccount.CardCash > 0 && sum > 0)
                        {
                            getAccount.CardCash = getAccount.CardCash - sum;

                            context.SaveChanges();

                            atmTransaction.Commit();

                            Console.WriteLine("Transaction complite.");
                            Console.Write("Would you like to see your balance(Y/N): ");
                            var readLine = Console.ReadLine();
                            if (readLine != null)
                            {
                                var line = readLine.ToUpper();
                                if (line == "Y")
                                {
                                    Console.WriteLine("Yor balance is {0:F2}lv.", getAccount.CardCash);
                                }
                                else
                                {
                                    Console.WriteLine("Have a nice day!");
                                }
                            }
                            var transHistory = new TransactionHistory()
                            {
                                CardNumber = getAccount.CardNumber,
                                TransactionDate = DateTime.Now,
                                Amount = getAccount.CardCash
                            };
                            context.TransactionHistories.Add(transHistory);
                            context.SaveChanges();

                        }
                        else
                        {

                            if (sum <= 0)
                            {
                                atmTransaction.Rollback();
                                Console.WriteLine("The transaction could not be proceed, because the withdraw sum has to be bigger than 0.");
                            }
                            else
                            {
                                atmTransaction.Rollback();

                                Console.WriteLine("The transaction could not be proceed, " +
                                                  "because your current balance is ({0:F2}lv).",
                                                  getAccount.CardCash, sum);
                            }
                           
                        }

                    }
                    else
                    {
                        atmTransaction.Rollback();

                        Console.WriteLine("Please, enter a correct pin number.");
                    }

                }
                catch (InvalidOperationException)
                {
                    atmTransaction.Rollback();

                    Console.WriteLine("Please, enter a correct 10 digits card number.");
                }

                
            }
            
        }

        
    }
}
