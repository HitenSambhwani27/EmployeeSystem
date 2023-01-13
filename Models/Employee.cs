
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Models
{
    public class Employee
    {
        [Required]  
        [Key]
        public int e_id { get; set; }
        public string employeefirstname { get; set; }
        public string employeelastname { get; set; }
        public string PhotoUrl { get; set; }
        /*public DateTime SignIn { get; set; }
        public DateTime SignOut { get; set; }*/

    }
}

