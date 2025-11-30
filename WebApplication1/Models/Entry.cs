using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Entry
    {
        public int Id { get; set; }

        // Powiązanie z Workout
        [Required]
        public int WorkoutId { get; set; }
        public Workout? Workout { get; set; }

        // Powiązanie z Exercise
        [Required]
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        // Parametry treningowe
        [Required]
        [Range(0, 1000, ErrorMessage = "Weight or Distance can't be negative.")]
        [Display(Name = "Weight/Distance")]
        public double Weight { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Number of sets can't be negative.")]
        [Display(Name = "Sets")]
        public int Sets { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Number of reps can't be negative.")]
        [Display(Name = "Reps")]
        public int Reps { get; set; }

        public string CreatedById { get; set; }
        [Display(Name = "Created by")]
        public virtual AppUser? CreatedBy { get; set; }

    }
}
