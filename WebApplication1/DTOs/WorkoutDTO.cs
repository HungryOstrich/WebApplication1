using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class WorkoutDTO
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public WorkoutDTO() { }

        public WorkoutDTO(Workout workout) 
        {
            Id = workout.Id;
            StartTime = workout.StartTime;
            EndTime = workout.EndTime;
        }
    }
}
