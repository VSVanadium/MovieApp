using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Entities
{
    public interface IDBContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<MovieActor> MovieActors { get; set; }
        void SaveChanges();
    }
}
