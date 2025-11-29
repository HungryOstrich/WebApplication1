using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class EntryDTO
    {
        public int Id { get; set; }
 
        public int WorkoutId { get; set; }
        public virtual Workout? Workout { get; set; }

        public int ExerciseId { get; set; }
        public virtual Exercise? Exercise { get; set; }
        public double Weight { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        public EntryDTO() { }

        public EntryDTO(Entry entry) 
        {
            Id = entry.Id;
            Weight = entry.Weight;
            Sets = entry.Sets;
            Reps = entry.Reps;
        }
    }
}
