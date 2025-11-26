using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        
        [Required]
        [Display(Name = "Ćwiczenie")]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        // Obciążenie w kg
        [Required]
        [Range(0, 1000)]
        [Display(Name = "Ciężar")]
        public double Weight { get; set; }

        // Liczba serii
        [Required]
        [Range(1, 100)]
        public int Sets { get; set; }

        // Liczba powtórzeń w każdej serii
        [Required]
        [Range(1, 200)]
        [Display(Name = "Powtórzenia")]
        public int Repetitions { get; set; }
        
    }
}
