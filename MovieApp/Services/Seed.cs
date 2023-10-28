using Bogus;
using ConsoleApp.Data;
using ConsoleApp.Entities;


namespace MovieApp.Services
{
    public static class Seed
    {
        public static void SeedMovies(ActorDBContext _dbContext)
        {
            var fakeMovies = new Faker<Movie>()
             .RuleFor(m => m.Id, f => f.Random.Guid())
             .RuleFor(m => m.Name, f => f.Random.Word())
             .RuleFor(m => m.ReleaseYear, f => f.Random.Number(1900, 2022))
             .RuleFor(m => m.Rating, f => f.Random.Enum<Rating>());


            var moviesToBeAdded = fakeMovies.Generate(10); // Generate 10 fake movies
            _dbContext.Movies.AddRange(moviesToBeAdded);

            _dbContext.SaveChanges();
        }

        public static void SeedActors(ActorDBContext _dbContext)
        {
           
        }

        public static void SeedMovieActorsMapping(ActorDBContext _dbContext)
        {            

        }
    }
}
