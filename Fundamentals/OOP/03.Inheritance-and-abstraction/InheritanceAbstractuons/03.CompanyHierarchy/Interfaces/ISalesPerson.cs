using System.Collections.Generic;
using _03.CompanyHierarchy.Employees.RegularEmployees.Occupations;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface ISalesPerson
    {
        IEnumerable<Sale> Sales { get; }
        void Add(Sale sale);
    }
}