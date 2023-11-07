using ConsoleApp.Entities;
using MovieApp.Data;

namespace ConsoleApp.Services
{
    public class MovieService
    {
        //TODO: convert into Builder pattern( movieBuilderService) and Test it
        //TODO: only movie.build do the database context changes and returns the object, title is manadatory
        private readonly ActorDBContext? _context;

        private Movie? movie;

        public MovieService(ActorDBContext context)
        {
            _context = context;
            movie = new Movie();
        }

        public Movie? AddTitle(string title)
        {
            if (string.IsNullOrEmpty(movie!.Name))
                throw new InvalidDataException($"Please provide a vaild movie name!");

            if (IfMovieWithTitleExists(movie.Name))
                throw new InvalidDataException($"A Movie :{movie.Name} with this title alread exists!!!");

            movie!.Name = title;
            return movie;
        }

        public Movie? Build()
        {
            _context?.Movies.Add(movie!);
            _context?.SaveChanges();

            movie = _context?.Movies.FirstOrDefault(x => x.Name == movie!.Name);
            return movie;
        }

        private bool IfMovieWithTitleExists(string movieTitle)
        {
            movie = _context?.Movies.FirstOrDefault(x => x.Name!.ToLower() == movieTitle.ToLower());
            return (movie != null) ? true : false;

        }
    }
}
