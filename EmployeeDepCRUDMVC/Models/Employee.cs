using System.ComponentModel.DataAnnotations;

namespace EmployeeDepCRUDMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Salary { get; set; }
        
        public string? ImageUrl { get; set; }
        [Required]
        public int DepID { get; set; }
        public string? DepName { get; set; }
    }
}
