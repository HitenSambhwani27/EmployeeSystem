using EmployeeSystem.Models;
using EmployeeSystem.Models;

namespace EmployeeSystem.Repository
{
    public interface IStudentRep
    {
        public IEnumerable<Employee> GetStudent(string employeefirstname,string employeelastname);
        public Employee GetStudent(string PhotoUrl);
        public IEnumerable<Employee> GetList();
        public Employee Add(Photo details);
    }
}
