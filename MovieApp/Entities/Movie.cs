using ConsoleApp.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Entities
{
    [Table("Movie")]
    public class Movie : Base
    {
        public int? ReleaseYear { get; set; }
        public Rating? Rating { get; set; }
        public ICollection<MovieActor>? MovieActors { get; set; }
    }
}
