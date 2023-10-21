using ConsoleApp.Entities;

namespace ConsoleApp.Services
{
    public class MovieService
    {
        private readonly ActorDBContext _context;

        public MovieService(ActorDBContext context)
        {
            _context = context;
        }

        public void AddMovie(string title, int releaseYear)
        {
            _context.Movies.Add(new Movie { Name = title, ReleaseYear = releaseYear });
            _context.SaveChanges();
        }

        public void AddActor(string name)
        {
            _context.Actors.Add(new Actor { Name = name });
            _context.SaveChanges();
        }

    }
}
