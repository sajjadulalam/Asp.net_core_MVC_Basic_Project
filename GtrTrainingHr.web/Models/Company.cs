using System.ComponentModel.DataAnnotations;

namespace GtrTrainingHr.web.Models
{
    public class Company
    {
        [StringLength(40)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(200)]
        public string? ComName { get; set; }
        [Required]
        public double Basic { get; set; }
        [Required]
        public double HRent { get; set; }
        [Required]
        public double Medical { get; set; }
        public bool IsInactive { get; set; } = true;
    }
}
