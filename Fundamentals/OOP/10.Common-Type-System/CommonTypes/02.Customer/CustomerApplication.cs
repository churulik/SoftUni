using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using _02.Customer.Models.Enums;

namespace _02.Customer
{
    using Models;
    internal class CustomerApplication
    {
        private static void Main()
        {
            var pizza = new Payment("Pizza", 5);
            var coffee = new Payment("Coffee", 2);
            var croason = new Payment("Croason", 1);

            var customerA = new Customer("Noumi", "Vi", "Chu", "8809023456",
                "str. Ivan Vazov", "0999998999", "vi@gmail.com", CustomerType.OneTime);
            customerA.Payments.Add(pizza);

            var customerB = new Customer("Noumi", "Vi", "Chu", "8809023456",
                "str. Ivan Vazov", "0999998999", "vi@gmail.com", CustomerType.OneTime);
            customerB.Payments.Add(pizza);

            var customerC = new Customer("Ivo", "Bi", "Rov", "8909023456",
                "str. Ivan Bujorv", "0999998988", "ivo@gmail.com", CustomerType.Diamond);

            var customerD = new Customer("Noumi", "Vi", "Chu", "8809023456",
                "str. Ivan Vazov", "0999998999", "vi@gmail.com", CustomerType.OneTime);
            customerD.Payments.Add(coffee);
            customerD.Payments.Add(croason);

            var customerE = new Customer("Noumi", "Vi", "Chu", "9809023456",
                "str. Ivan Vazov", "0999998999", "vi@gmail.com", CustomerType.OneTime);

            var customerF = new Customer("Galina", "Vi", "Chu", "8809023456",
                "str. Ivan Vazov", "0999998999", "vi@gmail.com", CustomerType.OneTime);
           

            Console.WriteLine("customerA == customerB: " + customerA.Equals(customerB)); // True
            Console.WriteLine("customerA == customerC: " + customerA.Equals(customerC)); // False
            Console.WriteLine("customerA == customerD: " + customerA.Equals(customerD)); // False
            Console.WriteLine("customerA == customerB: {0}", customerA == customerB); // True
            Console.WriteLine("customerA == customerC: {0}", customerA == customerC); // False
            Console.WriteLine("customerA != customerC: {0}", customerA != customerC); // True
            Console.WriteLine("customerA != customerD: {0}", customerA != customerD); // True
            Console.WriteLine();

            var hashCustomers = new HashSet<Customer> {customerA, customerB, customerC, customerD };
            foreach (var customer in hashCustomers)
            {
                Console.WriteLine(customer); //customerA, customerC, customerD
            }

            var clone = customerA.Clone();
            Console.WriteLine("clone == customerA: {0}", clone == customerA); //True
            Console.WriteLine("clone == customerB: {0}", clone == customerB); //True
            Console.WriteLine("clone == customerC: {0}", clone == customerC); //False

            Console.WriteLine();

            var customers = new List<Customer>() { customerA, customerB, customerC, customerD, customerE, customerF };
            customers.Sort();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName + " => " + customer.Id);
            }

        }
    }
}
