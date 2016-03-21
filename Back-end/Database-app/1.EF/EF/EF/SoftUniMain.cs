using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace EF
{
    class SoftUniMain
    {
        public static void Add(Employee employee)
        {
            var context = new SoftUniEntities();
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public static Employee FindById(object key)
        {
            var context = new SoftUniEntities();
            var findEmployeeByKey = context.Employees.Find(key);
            return findEmployeeByKey;
        }

        public static void Modify(Employee employee, string newName)
        {
            var context = new SoftUniEntities();
            var getId = context.Employees.Find(employee.EmployeeID);
            getId.FirstName = newName;
            context.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            var context = new SoftUniEntities();
            var getId = context.Employees.Find(employee.EmployeeID);
            context.Employees.Remove(getId);
            context.SaveChanges();
        }

        static void Main()
        {
            /* Problem 2.	Employee DAO Class */

            //Add(new Employee()
            //{
            //    FirstName = "Beni",
            //    LastName = "Nataniahu",
            //    JobTitle = "Manager",
            //    DepartmentID = 2,
            //    HireDate = DateTime.Now,
            //    Salary = 10000
            //});

            //var employee = FindById(1);
            //Console.WriteLine(employee.EmployeeID + " " + employee.FirstName + " " + employee.LastName);

            //Modify(new Employee(){EmployeeID = 3}, "Simeon");

            //Delete(new Employee() { EmployeeID = 294 });


            /* Problem 3.	Database Search Queries */

            /* 1. Find all employees who have projects started in the time period 2001 - 2003 (inclusive). 
             * Select each employee's first name, last name and manager name 
             * and each of their projects' name, start date, end date. */

            var context = new SoftUniEntities();

            var employees = from e in context.Employees
                            from p in e.Projects
                            join m in context.Employees on e.ManagerID equals m.EmployeeID
                            orderby e.FirstName
                            select new
                            {
                                EmployeeFirstName = e.FirstName,
                                EmployeeLastName = e.LastName,
                                ManagerFirstName = m.FirstName,
                                ManagerLastName = m.LastName,
                                ProjectName = p.Name,
                                ProjectStartDate = p.StartDate,
                                ProjectEndDate = p.EndDate
                            };
            var empoyeesB = context.Employees
                .Join(context.Employees,
                    e => e.ManagerID,
                    m => m.EmployeeID,
                    (e, m) => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Project = e.Projects.Select(p => p.Name),
                        Mananager = m.FirstName + " " + m.LastName
                    })
                    .OrderBy(e=>e.FirstName)
                    .ToList();
            //foreach (var em in empoyeesB)
            //{
            //    Console.WriteLine(em.FirstName + em.LastName + " - " + em.Mananager);
            //}

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} {1} - Manager: {2} {3}\n Projetc name: {4}\n Start: {5}\n End: {6}",
            //        employee.EmployeeFirstName,
            //        employee.EmployeeLastName,
            //        employee.ManagerFirstName,
            //        employee.ManagerLastName,
            //        employee.ProjectName,
            //        employee.ProjectStartDate,
            //        employee.ProjectEndDate);
            //}

            /* 2. Find all addresses, 
             * ordered by the number of employees who live there (descending), 
             * then by town name (ascending). 
             * Take only the first 10 addresses and select their address text, town name and employee count. */

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees.Count
                });

            //foreach (var address in addresses)
            //{
            //    Console.WriteLine("{0}, {1} - {2} employees",
            //        address.AddressText,
            //        address.Name,
            //        address.Count);
            //}


            /* 3.	Get an employee by id (e.g. 147). 
             * Select only his/her first name, last name, job title and projects (only their names). 
             * The projects should be ordered by name (ascending).*/

           // Variant 1
            var employeeById = from e in context.Employees
                               from p in e.Projects
                               where e.EmployeeID == 147
                               orderby p.Name
                               select new
                               {
                                   e.FirstName,
                                   e.LastName,
                                   e.JobTitle,
                                   p.Name
                               };

            //foreach (var employee in employeeById)
            //{
            //    Console.WriteLine("{0} {1} - {2} ({3})",
            //        employee.FirstName,
            //        employee.LastName,
            //        employee.JobTitle,
            //        employee.Name);
            //}

           // Variant 2

            var getEmployee = from e in context.Employees
                              where e.EmployeeID == 147
                              select new
                              {
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  JobTitle = e.JobTitle,
                                  ProjectName = e.Projects.Select(p => p.Name)
                              };

            //foreach (var employee in getEmployee)
            //{
            //    Console.WriteLine("{0} {1} ({2})",
            //        employee.FirstName,
            //        employee.LastName,
            //        employee.JobTitle);
            //    foreach (var projetcs in employee.ProjectName)
            //    {
            //        Console.WriteLine("Projetc: " + projetcs);
            //    }
            //}

            /* 4. Find all departments with more than 5 employees. 
             * Order them by employee count (ascending). 
             * Select the department name, manager name and first name, last name, 
             * hire date and job title of every employee. */

            // Variant 1
            var deparmentsA = from d in context.Departments
                             join e in context.Employees on d.ManagerID equals e.EmployeeID
                             join w in context.Employees on d.DepartmentID equals w.DepartmentID
                             where d.Employees.Count > 5
                             group d by new
                             {
                                 d.Name,
                                 e.LastName,
                                 d.Employees.Count
                             } into g
                             orderby g.Key.Count
                             select new
                             {
                                 DepartmenName = g.Key.Name,
                                 ManagerName = g.Key.LastName,
                                 Employees = g.Key.Count
                             };

            //Console.WriteLine(deparmentsA.Count());

            //foreach (var department in deparmentsA)
            //{
            //    Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
            //        department.DepartmenName,
            //        department.ManagerName,
            //        department.Employees);
            //}

            // Varinat 2

            var departmentsB = from d in context.Departments
                join e in context.Employees on d.ManagerID equals e.EmployeeID
                join w in context.Employees on d.DepartmentID equals w.DepartmentID
                where d.Employees.Count > 5
                group d by new
                {
                    DepartmentName = d.Name,
                    ManagerName = e.FirstName + " " + e.LastName,
                    EmployeeName = w.FirstName + " " + w.LastName,
                    HireDate = w.HireDate,
                    JobTitle = w.JobTitle,
                    Count = d.Employees.Count
                } into g
                orderby g.Key.Count  
                select g;

            //foreach (var department in departmentsB)
            //{
            //    Console.WriteLine("--{0} - Manager: {1}, Employees: {2}, Hire date: {3}, Job title: {4}",
            //        department.Key.DepartmentName,
            //        department.Key.ManagerName,
            //        department.Key.EmployeeName,
            //        department.Key.HireDate,
            //        department.Key.JobTitle);
            //}


            /* Problem 4.	Native SQL Query */

            var sw = new Stopwatch();
            sw.Start();

            const string nativeQ = "SELECT FirstName FROM Employees e " +
                                   "JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID " +
                                   "JOIN Projects p ON p.ProjectID = ep.ProjectID " +
                                   "WHERE YEAR(p.StartDate) = {0}";

            var employeesQ = context.Database.SqlQuery<string>(nativeQ, "2002");

            //foreach (var employee in employeesQ)
            //{
            //    Console.WriteLine(employee);
            //}

            //Console.WriteLine("Native: {0}", sw.Elapsed);

            //sw.Restart();

            var linqA = from e in context.Employees
                        from p in e.Projects
                        where p.StartDate.Year == 2002
                        select e.FirstName;

            //foreach (var lA in linqA)
            //{
            //    Console.WriteLine(lA);
            //}
            //Console.WriteLine("Linq: {0}", sw.Elapsed);

            //sw.Restart();

            var linqB = context.Projects
                .Where(p => p.StartDate.Year == 2002)
                .SelectMany(e => e.Employees)
                .Select(e => e.FirstName);

            //foreach (var lB in linqB)
            //{
            //    Console.WriteLine(lB);
            //}
            //Console.WriteLine("Linq: {0}", sw.Elapsed);


            /* Problem 5.	Concurrent Database Changes with EF */

            //using (var contextA = new SoftUniEntities())
            //{
            //    var changeA = contextA.Employees.First();
            //    changeA.FirstName = "Simu";

            //    using (var contextB = new SoftUniEntities())
            //    {
            //        var changeB = contextB.Employees.First();
            //        changeB.FirstName = "Tosho";
            //        contextB.SaveChanges();
            //    }
            //    contextA.SaveChanges();
            //}


            /* Problem 6.	Call a Stored Procedure */

            var allProjects = context.FindProjects("JoLynn", "Dobney");

        //    foreach (var project in allProjects)
        //    {
        //        Console.WriteLine(project.ProjetcName + " - " + project.Description + " Start: " + project.StartDate);
        //    }
        }
    }
}
