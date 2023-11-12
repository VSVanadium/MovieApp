using ConsoleApp.Entities;
using MovieApp.Data;

namespace ConsoleApp.Services
{
    public class MovieService
    {
        
        private readonly ActorDBContext? _context;
        private Movie movie = new Movie();

        public MovieService(ActorDBContext context)
        {
            _context = context;
        }

        public MovieService AddTitle(string title)
        {
            if (string.IsNullOrEmpty(movie!.Name))
                throw new InvalidDataException($"Please provide a vaild movie name!");

            if (IfMovieWithTitleExists(movie.Name))
                throw new InvalidDataException($"A Movie :{movie.Name} with this title alread exists!!!");

            movie!.Name = title;
            return this;
        }

        public MovieService AddReleaseYear(int releaseYear)
        {
            //TODO: validation release year > 1900
            movie!.ReleaseYear = releaseYear;
            return this;
        }

        public MovieService AddGenre(Genre genre)
        {
            //TODO: add genre
            return this;
        }

        public MovieService AddRating(decimal rating)
        {
            //TODO: calidation between 0 to 5,  add rating
            return this;
        }

        public MovieService Build()
        {
            _context?.Movies.Add(movie!);
            _context?.SaveChanges();

            movie = _context?.Movies.FirstOrDefault(x => x.Name == movie!.Name);
            return this;
        }

        private bool IfMovieWithTitleExists(string movieTitle)
        {
            movie = _context?.Movies.FirstOrDefault(x => x.Name!.ToLower() == movieTitle.ToLower());
            return (movie != null) ? true : false;

        }
    }
}
