using System;
using System.Collections.Generic;
using System.ComponentModel;
using _03.CompanyHierarchy.Employees.Enums;
using _03.CompanyHierarchy.Employees.RegularEmployees.Occupations;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Employees.RegularEmployees
{
    public class SalesPerson : RegularEmployee, ISalesPerson
    {
        private readonly List<Sale> sales; 

        public SalesPerson(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName, salary, department)
        {
            this.sales = new List<Sale>();
        }

        public IEnumerable<Sale> Sales { get { return this.sales; } }
        public void Add(Sale sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException("The sale cannot be empty.");
            }
            this.sales.Add(sale);
        }

        public override string ToString()
        {
            var output = "Sales:\n";
            foreach (var sale in this.Sales)
            {
                output += $"\n\tProduct Name: {sale.ProductName}\n" +
                          $"\tDate: {sale.Date.ToLongDateString()}\n" +
                          $"\tPrice: {sale.Price} lv.\n";
            }
            return base.ToString() + output;
        }
    }
}