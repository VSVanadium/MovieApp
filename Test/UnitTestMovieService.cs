using ConsoleApp.Entities;
using ConsoleApp.Services;
using MovieApp.Data;

namespace Test
{
    public class UnitTestMovieService
    {
        private ActorDBContextInMemory _dbContext;
        private MovieService? _movieService;

        [SetUp]
        public void Setup()
        {
            _dbContext = new ActorDBContextInMemory();
            _movieService = new MovieService(_dbContext);
        }


        [Test]
        public void AddMovie_ShouldAddMovieToDatabase()
        {
            // Arrange
            string movieTitle = "Everything everywhere all at once!";
            int releaseYear = 2022;

            // Act
            var movie = _movieService!
                       .AddTitle(movieTitle)
                       .AddReleaseYear(releaseYear)
                       .AddGenre(Genre.Scifi)
                       .Build();
            

            // Assert           
            Assert.NotNull(movie);
            Assert.That(movie.Name, Is.EqualTo(movieTitle));
            Assert.That(movie.ReleaseYear, Is.EqualTo(releaseYear));

        }

        public void AddMovie_ShouldNotAddMovieToDatabase_DuplicateTitle()
        {

        }

        public void AddMovie_ShouldNotAddMovieToDatabase_WrongReleaseYear()
        {

        }

    }
}
