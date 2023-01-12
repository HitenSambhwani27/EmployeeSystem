using December_Project.Models;
using OKRProject.Models;

namespace December_Project.Repository
{
    public interface IStudentRepository
    {
        public IEnumerable<Employee> GetStudent(string employeefirstname,string employeelastname);
        public Employee GetStudent(string PhotoUrl);
        public IEnumerable<Employee> GetList();
        public Employee Add(Photo details);
    }
}
