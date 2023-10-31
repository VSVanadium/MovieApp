using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieApp.Services;

Console.WriteLine("Hello, welcome to movie library!");

IConfiguration configuration = new ConfigurationBuilder()
           .AddUserSecrets<Program>().Build();


using (var dbContext = new ActorDBContext(configuration))
{
    //create
    Seed.SeedMovies(dbContext);
    Seed.SeedActors(dbContext);
    Seed.SeedMovieActorsMapping(dbContext);

    //fetch
    var moviesWithActors = dbContext.Movies
       .Include(m => m.MovieActors)
       .Where(m => m.ReleaseYear == 2014 || m.ReleaseYear == 1973)
       .Select(m => new
       {
           MovieTitle = m.Name,
           ReleaseYear = m.ReleaseYear,
           Actors = m.MovieActors!.Select(ma => ma.Actor!.Name).ToList()
       })
       .ToList();

    foreach (var movie in moviesWithActors)
    {
        Console.WriteLine($"Movie: {movie.MovieTitle} ({movie.ReleaseYear})");
        Console.WriteLine("Actors:");
        foreach (var actor in movie.Actors)
        {
            Console.WriteLine($"- {actor}");
        }
        Console.WriteLine();
    }


    Console.ReadLine();
}