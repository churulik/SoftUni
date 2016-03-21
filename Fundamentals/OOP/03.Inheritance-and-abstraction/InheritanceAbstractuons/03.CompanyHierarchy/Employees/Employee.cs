using System;
using _03.CompanyHierarchy.Employees.Enums;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Employees
{
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;

        protected Employee(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid salary.");
                }
                this.salary = value;
            }
        }

        public Department Department { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Department: {this.Department}\n" +
                   $"Salary: {this.Salary} lv.\n";
        }
    }
}