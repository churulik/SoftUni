using System;
using System.Collections.Generic;
using _03.CompanyHierarchy.Employees.Enums;
using _03.CompanyHierarchy.Employees.RegularEmployees.Projects;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Employees.RegularEmployees
{
    public class Developer : RegularEmployee, IDeveloper
    {
        private readonly List<Project> projects; 
       
        public Developer(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName, salary, department)
        {
            this.projects = new List<Project>();
        }

        public IEnumerable<Project> Projects { get { return this.projects; } }

        public void Add(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException("The project cannot be empty.");
            }
            this.projects.Add(project);
        }

        public override string ToString()
        {
            var output = "Projects:\n";
            foreach (var project in this.Projects)
            {
                output += $"\n\tProject Name: {project.ProjectName}\n" +
                          $"\tStart Date: {project.StartDate.ToLongDateString()}\n" +
                          $"\tState: {project.State}\n" +
                          $"\tDetails: {project.Details ?? "None"}\n";
            }
            return base.ToString() + output;
        }
    }
}