using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Workout
    {
        //Dane do sesji treningowej
        public int Id { get; set; }

        [Required]
        [Display(Name = "Start of workout")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Data i czas zakończenia")]
        public DateTime EndTime { get; set; }
        
        //Powiązanie z użytkownikiem

        [Display(Name = "Created by")]
        public string CreatedById { get; set; }
        [Display(Name = "Created by")]
        public virtual AppUser? CreatedBy { get; set; }
    }
}
