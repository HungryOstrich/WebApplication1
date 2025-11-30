using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Exercise
    {
        //Ćwiczenie
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
       
    }
}
