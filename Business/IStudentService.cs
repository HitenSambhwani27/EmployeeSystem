using December_Project.Models;
using OKRProject.Models;

namespace December_Project.Business
{
    public interface IStudentService
    {
        public IEnumerable<Employee> GetStudents(string employeefirstname, string employeelastname);
        public Employee GetStudent(string PhotoUrl);
        public IEnumerable<Employee> GetList();
        public Employee Add(Photo details);

    }
}
