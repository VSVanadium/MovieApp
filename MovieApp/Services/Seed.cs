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
            var characterNames = new List<string>
            {
                "John Doe",
                "Alice Johnson",
                "Michael Smith",
                "Emma Thompson",
                "Leonardo DiCaprio",
                "Tom Hanks",
                "Brad Pitt",
                "Bradley Cooper",
                "Hugh Jackman",
                "Nicole Kidman",
                "Emily Blunt"
            };

            var fakeActors = new Faker<Actor>()
                .RuleFor(a => a.Id, f => f.Random.Guid())
                .RuleFor(a => a.Name, f => f.PickRandom(characterNames))
                .RuleFor(a => a.Age, f => f.Random.Number(12, 89))
                .RuleFor(a => a.AcademyWinner, f => f.Random.Bool());

            var actorsToBeAdded = fakeActors.Generate(10); // Generate 10 fake actors
            _dbContext.Actors.AddRange(actorsToBeAdded);

            _dbContext.SaveChanges();

        }

        public static void SeedMovieActorsMapping(ActorDBContext _dbContext)
        {
            var allMovies = _dbContext.Movies.Select(x => x.Id).Take(10).ToList();
            var allActors = _dbContext.Actors.Select(x => x.Id).Take(10).ToList();

            var movieActors = new Faker<MovieActor>()
            .RuleFor(ma => ma.MovieId, f => f.PickRandom(allMovies))
            .RuleFor(a => a.ActorId, f => f.PickRandom(allActors));

            var mappingsToBeAdded = movieActors.Generate(10); // Generate 10 fake mappings
            _dbContext.MovieActors.AddRange(mappingsToBeAdded);

            _dbContext.SaveChanges();
        }
    }
}
