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
            movie.Name = title;
            return this;
        }

        public MovieService AddReleaseYear(int releaseYear)
        {
            //TODO: validation release year > 1900
            movie.ReleaseYear = releaseYear;
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
            return movie;
        }

    }
}
