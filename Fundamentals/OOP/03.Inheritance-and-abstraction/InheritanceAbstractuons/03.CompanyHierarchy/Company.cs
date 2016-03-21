using System;
using System.Collections.Generic;
using _03.CompanyHierarchy.Customers;
using _03.CompanyHierarchy.Employees;
using _03.CompanyHierarchy.Employees.Enums;
using _03.CompanyHierarchy.Employees.Manager;
using _03.CompanyHierarchy.Employees.RegularEmployees;
using _03.CompanyHierarchy.Employees.RegularEmployees.Occupations;
using _03.CompanyHierarchy.Employees.RegularEmployees.Projects;

namespace _03.CompanyHierarchy
{
    class Company
    {
        static void Main()
        {
            var oop = new Project("OOP", new DateTime(2015, 11, 12), State.Open);
            var cSharp = new Project("C#", new DateTime(2015, 9, 9), State.Closed);
            var javaScript = new Project("Java Script", new DateTime(2015, 12, 1), State.Closed);
            var css = new Project("CSS", DateTime.Now, State.Open);

            var oranges = new Sale("Oranges", new DateTime(2015, 11, 1), 2.5m);
            var bananas = new Sale("Bananas", new DateTime(2015, 10, 19), 2);
            var mazda = new Sale("Mazda", new DateTime(2015, 12, 11), 20500);
            var porshe = new Sale("Porshe", new DateTime(2015, 12, 12), 120300);

            var developerDotNet = new Developer(1, "Dimitar", "Iskrenov", 3000, Department.Production);
            developerDotNet.Add(oop);
            developerDotNet.Add(cSharp);

            var developerFrontEnd = new Developer(2, "Ico", "Popov", 12000, Department.Production);
            developerFrontEnd.Add(javaScript);
            developerFrontEnd.Add(css);

            var salesPersonGrocery = new SalesPerson(1, "Trifon", "Ivanov", 15000, Department.Sales);
            salesPersonGrocery.Add(oranges);
            salesPersonGrocery.Add(bananas);

            var salesPersonVeichals = new SalesPerson(2, "Gergan", "Kirchev", 1300000, Department.Sales);
            salesPersonVeichals.Add(mazda);
            salesPersonVeichals.Add(porshe);

            var managerProduction = new Manager(1, "Tsvetan", "Ivanov", 130000, Department.Production);
            managerProduction.Add(developerDotNet);
            managerProduction.Add(developerFrontEnd);

            var managerSales = new Manager(2, "Iliana", "Ivanova", 120000, Department.Sales);
            managerSales.Add(salesPersonGrocery);
            managerSales.Add(salesPersonVeichals);
            
            var allEmployees = new List<Person>
            {
                managerProduction,
                managerSales,
                developerDotNet,
                developerFrontEnd,
                salesPersonGrocery,
                salesPersonVeichals
            };

            foreach (var employee in allEmployees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
