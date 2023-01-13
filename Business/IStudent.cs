using EmployeeSystem.Models;
using EmployeeSystem.Models;

namespace EmployeeSystem.Business
{
    public interface IStudent
    {
        public IEnumerable<Employee> GetStudents(string employeefirstname, string employeelastname);
        public Employee GetStudent(string PhotoUrl);
        public IEnumerable<Employee> GetList();
        public Employee Add(Photo details);

    }
}
