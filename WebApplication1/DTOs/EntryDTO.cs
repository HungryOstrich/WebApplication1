using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class EntryDTO
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
        [Range(0, 1000, ErrorMessage = "Obciążenie musi być wartością nieujemną.")]
        [Display(Name = "Obciążenie (kg)")]
        public double Weight { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Liczba serii musi być dodatnia.")]
        [Display(Name = "Liczba serii")]
        public int Sets { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Liczba powtórzeń musi być dodatnia.")]
        [Display(Name = "Powtórzenia w serii")]
        public int Reps { get; set; }
    }
}
