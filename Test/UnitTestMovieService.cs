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
            

        }

        public void AddMovie_ShouldNotAddMovieToDatabase_DuplicateTitle()
        {

        }

        public void AddMovie_ShouldNotAddMovieToDatabase_WrongReleaseYear()
        {

        }

    }
}
