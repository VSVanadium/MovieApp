using ConsoleApp.Data;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleApp.Entities
{
    [Table("Actor")]
    public class Actor : Base
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool AcademyWinner { get; set; }
        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
