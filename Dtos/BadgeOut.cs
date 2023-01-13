
using EmployeeSystem.Models;
namespace EmployeeSystem.Dtos
{
    public class BadgeOut
    {
        public string PhotoUrl { get; set; }
        public int e_id { get; set; }
        public string employeefirstname { get; set; }
        public string employeelastname { get; set; }
        public int TemporaryBadge { get; set; }
        public Nullable<DateTime> SignIn { get; set; }
        public Nullable<DateTime> SignOut { get; set; }
        public Nullable<DateTime> AssignTime { get; set; }

    }
}
