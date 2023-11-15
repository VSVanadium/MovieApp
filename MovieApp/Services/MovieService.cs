using ConsoleApp.Entities;
using MovieApp.Data;
using MovieApp.Entities;

namespace ConsoleApp.Services
{
    public class MovieService
    {
        
        private readonly IDBContext? _context;
        private Movie movie = new Movie();

        public MovieService(IDBContext context)
        {
            _context = context;
        }

        public MovieService AddTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new InvalidDataException($"Please provide a vaild movie name!");

            if (IfMovieWithTitleExists(title))
                throw new InvalidDataException($"A Movie :{title} with this title alread exists!!!");

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
            movie.Genre = genre;
            return this;
        }

        public MovieService AddRating(decimal rating)
        {
            //TODO: calidation between 0 to 5,  add rating
            return this;
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
