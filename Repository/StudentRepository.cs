using December_Project.DBContext;
using December_Project.Models;
using Microsoft.EntityFrameworkCore;
using OKRProject.Models;

namespace December_Project.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext DB ;
        private IWebHostEnvironment environment;

        public StudentRepository(AppDBContext DB , IWebHostEnvironment environment)
        {
            this.DB = DB;
            this.environment = environment;
        }
        public IEnumerable<Employee> GetStudent(string employeefirstname, string employeelastname)
        {
            if(employeefirstname != null && employeelastname == null || employeefirstname == null && employeelastname != null) 
            { 
            return DB.Employee.ToList().Where(e => (e.employeefirstname == employeefirstname || e.employeelastname == employeelastname));
            }
            return DB.Employee.ToList().Where(e => (e.employeefirstname == employeefirstname || e.employeelastname == employeelastname));
        }
        public Employee GetStudent(string PhotoUrl)
        {
            return DB.Employee.Where(e =>e.PhotoUrl==PhotoUrl ).FirstOrDefault();
        }
        public IEnumerable<Employee> GetList()
        {
            return DB.Employee.ToList();
        }
        public Employee Add(Photo details)
        {
            string UniqueFileName = null;
            if (details.PhotoUrl!= null)
            {
                UniqueFileName = Guid.NewGuid().ToString() + "_" + details.PhotoUrl.FileName;
                string UploadFolder = Path.Combine(environment.WebRootPath, "images");
                string FilePath = Path.Combine(UploadFolder, UniqueFileName);
                details.PhotoUrl.CopyTo(new FileStream(FilePath, FileMode.Create));
            }
            Employee newEmployee = new Employee()
            {
                e_id = details.e_id,
                employeefirstname = details.employeefirstname,
                employeelastname = details.employeelastname,
                PhotoUrl = UniqueFileName
            };

            DB.Employee.Add(newEmployee);
            DB.SaveChanges();

            return newEmployee;

        }

    }
}
