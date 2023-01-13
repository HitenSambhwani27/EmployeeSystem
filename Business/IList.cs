using EmployeeSystem.Models;

namespace EmployeeSystem.Business
{
    public interface IList
    {
        IEnumerable<Employee> Getlist();
    }
}
