using System.ComponentModel.DataAnnotations;

namespace December_Project.Models
{
    public class Guard
    {
        [Key]
        public int G_Id { get; set; }
        public string employeefirstname { get; set; }
        public string employeelastname { get; set; }
        public int TemporaryBadge { get; set; }
        public  Nullable<DateTime> SignIn { get; set; } 
        public Nullable<DateTime> SignOut { get; set; }
        public Nullable<DateTime> AssignTime { get; set; }
        public int? e_id { get; set; }

    }
}
