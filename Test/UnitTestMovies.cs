using ConsoleApp.Entities;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test
{
    [TestFixture]
    public class Tests
    {
        private ActorDBContextInMemory _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new ActorDBContextInMemory();
        }

        [Test]
        public void AddMovie_ShouldAddMovieToDatabase()
        {
            // Arrange
            string movieTitle = "Everything everywhere all at once!";
            int releaseYear = 2022;

            // Act
            _dbContext.Movies.Add(new Movie() { Id = Guid.NewGuid(), Name = movieTitle, ReleaseYear = releaseYear });
            _dbContext.SaveChanges();

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
            _dbContext.Actors.Add(new Actor() { Name = actorName });
            _dbContext.SaveChanges();

            // Assert
            var addedActor = _dbContext.Actors.FirstOrDefault(a => a.Name == actorName);
            Assert.NotNull(addedActor);
        }
    }
}