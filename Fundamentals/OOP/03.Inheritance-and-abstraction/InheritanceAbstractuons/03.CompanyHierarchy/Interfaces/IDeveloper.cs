using System.Collections.Generic;
using _03.CompanyHierarchy.Employees.RegularEmployees.Projects;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface IDeveloper
    {
        IEnumerable<Project> Projects { get; }
        void Add(Project project);
    }
}