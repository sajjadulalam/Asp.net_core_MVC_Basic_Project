using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GtrTrainingHr.web.Models
{

    public class Attendance
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public DateTime dtDate { get; set; }
        [Required]
        [StringLength(50)]
        public string? AttStatus { get; set;}
        [Required]
        public DateTime InTime { get; set; }
        [Required]
        public DateTime OutTime { get; set; }
        [Required]
        public string? CompanyId { get; set; }
        public Company? Company { get; set; }
        [Required]
        public string? EmpId { get; set; }
        public Employee? Emp { get; set; }

    }
}
