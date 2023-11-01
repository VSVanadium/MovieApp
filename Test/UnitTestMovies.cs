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

        [Test]
        public void AddActor_ShouldAddMovieActorMappingToDatabase()
        {
            // Arrange
            string movieTitle = "harry potter and the prisoner of azkaban";
            int releaseYear = 2004;

            string actor1Name = "Daniel Radcliffe";
            string actor2Name = "Emma Watson";

            var movie = new Movie() { Id = Guid.NewGuid(), Name = movieTitle, ReleaseYear = releaseYear };
            var actor1 = new Actor() { Id = Guid.NewGuid(), Name = actor1Name, Age = 34 };
            var actor2 = new Actor() { Id = Guid.NewGuid(), Name = actor2Name, Age = 31 };

            _dbContext.Movies.Add(movie);
            _dbContext.Actors.Add(actor1);
            _dbContext.Actors.Add(actor2);

            _dbContext.MovieActors.Add(new MovieActor(movie.Id, actor1.Id));
            _dbContext.MovieActors.Add(new MovieActor(movie.Id, actor2.Id));

            _dbContext.SaveChanges();

            // Act
            var result = _dbContext.Movies.Include(m => m.MovieActors).Where(x => x.MovieActors!.Any(x => x.Actor!.Name == actor1.Name)).FirstOrDefault();

            // Assert
            Assert.NotNull(result);
            Assert.That(result?.Name, Is.EqualTo(movieTitle));

        }
    }
}