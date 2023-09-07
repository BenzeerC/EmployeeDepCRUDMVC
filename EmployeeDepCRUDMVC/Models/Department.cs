using System.ComponentModel.DataAnnotations;

namespace EmployeeDepCRUDMVC.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        [Required]
        public string? DepName { get; set;}
    }
}
