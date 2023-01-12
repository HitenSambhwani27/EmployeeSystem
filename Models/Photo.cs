using System.ComponentModel.DataAnnotations;

namespace OKRProject.Models
{
    public class Photo
    {
        [Required]  
        [Key]
        public int e_id { get; set; }
        public string employeefirstname { get; set; }
        public string employeelastname { get; set; }
        public IFormFile PhotoUrl { get; set; }
    }
}
