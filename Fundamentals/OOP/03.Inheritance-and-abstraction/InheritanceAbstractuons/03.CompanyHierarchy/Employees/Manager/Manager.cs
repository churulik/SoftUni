using System;
using System.Collections.Generic;
using _03.CompanyHierarchy.Employees.Enums;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Employees.Manager
{
    public class Manager : Employee, IManager
    {
        private readonly List<Employee> employees;

        public Manager(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName, salary, department)
        {
            this.employees = new List<Employee>();
        }
        
        public IEnumerable<Employee> Employees { get { return this.employees; } }

        public void Add(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("The employee cannot be empty.");
            }
            this.employees.Add(employee);
        }

        public override string ToString()
        {
            var output = "Employees:\n";
            foreach (var employee in this.Employees)
            {
                output += $"\n\tName: {employee.FirstName} {employee.LastName}\n" +
                          $"\tDepartment: {employee.Department}\n" +
                          $"\tSalary: {employee.Salary} lv.\n";
            }
            return base.ToString() + output;
        }

        
    }
}