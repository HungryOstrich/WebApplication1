using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Workout
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data i czas rozpoczęcia")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Data i czas zakończenia")]
        public DateTime EndTime { get; set; }
    }
}
