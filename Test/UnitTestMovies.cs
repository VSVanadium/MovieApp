using ConsoleApp.Entities;
using ConsoleApp.Services;


namespace Test
{
    [TestFixture]
    public class Tests
    {
        private ActorDBContext _dbContext;
        private MovieService _movieService;
        private readonly string _connectionString = "Server=localhost\\SQLEXPRESS;Database=ActorDB;Trusted_Connection=True;TrustServerCertificate=True";

        [SetUp]
        public void Setup()
        {
            _dbContext = new ActorDBContext(_connectionString);
            _movieService = new MovieService(_dbContext);

        }

        [Test]
        public void AddMovie_ShouldAddMovieToDatabase()
        {
            // Arrange
            string movieTitle = "Everything everywhere all at once!";
            int releaseYear = 2022;

            // Act
            _movieService.AddMovie(movieTitle, releaseYear);

            // Assert
            var addedMovie = _dbContext.Movies.FirstOrDefault(m => m.Name == movieTitle && m.ReleaseYear == releaseYear);
            Assert.NotNull(addedMovie);

        }

        [Test]
        public void AddActor_ShouldAddActorToDatabase()
        {
            // Arrange
            string actorName = "Michelle Yeoh";

            // Act
            _movieService.AddActor(actorName);

            // Assert
            var addedActor = _dbContext.Actors.FirstOrDefault(a => a.Name == actorName);
            Assert.NotNull(addedActor);
        }
    }
}