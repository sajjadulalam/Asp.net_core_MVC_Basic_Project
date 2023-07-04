using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GtrTrainingHr.web.Models
{
    
    public class Employee
    {
        [StringLength(40)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(150)]
        public string? EmpName { get; set; }
        [Required]
        
        public Gender Gender { get; set; }
        [Required]
        [Range (10000, 100000)]
        public double Gross { get; set; }
        [Required]
        public double Basic { get; set; }
        [Required]
        public double HRent { get; set; }
        [Required]
        public double Medical { get; set; }
        [Required]
        public double Others { get; set; }
        [Required]
        public DateTime dtJoin { get; set; }
        [Required]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }

        [Required]
        public string? ShiftId { get; set; }
        public Shift? Shift { get; set; }
        [Required]
        public string? DeptId { get; set;}
        public Department? Dept { get; set; }
        [Required]
        public string? DesigId { get; set; }
        public Designation? Desig { get; set; }
        


    }
    public enum Gender
    {
        Male,Female,Others
    }
}
