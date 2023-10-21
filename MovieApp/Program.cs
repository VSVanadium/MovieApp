using ConsoleApp.Data;
using ConsoleApp.Entities;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, welcome to movie library!");

IConfiguration configuration = new ConfigurationBuilder()
           .AddUserSecrets<Program>().Build();


using (var dbContext = new ActorDBContext(configuration))
{
    //create
    Actor actor1 = new Actor() { Name = "Tom Cruise", Age = 52, Gender = Gender.Male, AcademyWinner = false };
    Actor actor2 = new Actor() { Name = "Emily Blunt", Age = 38, Gender = Gender.Female, AcademyWinner = true };

    //create movie
    Movie movie1 = new Movie() { Name = "Edge of tomorrow", ReleaseYear = 2014, Rating = Rating.fourStar };


    //seed
    dbContext.Actors.Add(actor1);
    dbContext.Actors.Add(actor2);

    dbContext.Movies.Add(movie1);

    dbContext.MovieActors.Add(new MovieActor() { Movie = movie1, Actor = actor1 });
    dbContext.MovieActors.Add(new MovieActor() { Movie = movie1, Actor = actor2 });

    //save to database
    var count = dbContext.SaveChanges();

    //fetch
    var moviesWithActors = dbContext.Movies
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