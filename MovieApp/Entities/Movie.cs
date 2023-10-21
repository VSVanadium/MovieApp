using ConsoleApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
