using EmployeeSystem.Models;
using EmployeeSystem.Repository;
using EmployeeSystem.Models;

namespace EmployeeSystem.Business
{
    public class Student : IStudent
    {
        private readonly IStudentRep _student;

        public Student(IStudentRep student)
        {
            _student = student;
        }

        public IEnumerable<Employee> GetStudents(string employeefirstname, string employeelastname)
        {
            return _student.GetStudent(employeefirstname,employeelastname);
        }
        public Employee GetStudent(string PhotoUrl)
        {
            return _student.GetStudent(PhotoUrl);
        }
        public IEnumerable<Employee> GetList()
        {
            return _student.GetList();
        }
        public Employee Add(Photo details)
        {
            return _student.Add(details);
        }
    }
}
