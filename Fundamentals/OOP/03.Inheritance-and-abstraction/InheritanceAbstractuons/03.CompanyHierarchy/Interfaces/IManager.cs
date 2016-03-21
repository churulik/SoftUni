using System.Collections.Generic;
using _03.CompanyHierarchy.Employees;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface IManager
    {
        IEnumerable<Employee> Employees { get; }
        void Add(Employee employee);
    }
}