using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GtrTrainingHr.web.Models
{
    
    public class AttendanceSummary
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public int dtYear { get; set; }
        [Required]
        public int dtMonth { get; set; }
        [Required]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }

        [Required]
        public string? EmpId { get; set; }
        public Employee? Emp { get; set; }
        public int Present{ get; set; }
        public int Absent{ get; set; }
        public int Late{ get; set; }
        public int Weekend { get; set; }

        public Salary? Salary { get; set; }
    }
}
