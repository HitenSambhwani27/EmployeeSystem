using December_Project.Models;
using December_Project.Repository;
using OKRProject.Models;

namespace December_Project.Business
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _student;

        public StudentService(IStudentRepository student)
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
