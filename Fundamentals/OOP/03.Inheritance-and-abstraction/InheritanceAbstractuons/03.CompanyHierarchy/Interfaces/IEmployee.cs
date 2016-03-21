using _03.CompanyHierarchy.Employees.Enums;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface IEmployee
    {
        decimal Salary { get; set; }
        Department Department { get; set; }
    }
}