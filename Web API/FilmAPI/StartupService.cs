using FilmAPI.Models.Film;
using FilmAPI.Models.FilmStudio;
using FilmAPI.Models.User;

namespace FilmAPI
{
    public class StartupService : IHostedService
    {

        private readonly IServiceScopeFactory _scopeFactory;

        public StartupService(IServiceScopeFactory scopeFactory)
        {
            // Inject the scope factory
            _scopeFactory = scopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a new scope (since DbContext is scoped by default)
            using var scope = _scopeFactory.CreateScope();

            // Get a Dbcontext from the scope
            var db = scope.ServiceProvider
                .GetRequiredService<FilmDbContext>();

            // add new admin user
            db.Users.Add(new User
            {
                UserId = "1",
                Username = "admin",
                Password = "admin",
                Role = "admin"
            });

            var filmStudio = new FilmStudio
            {
                FilmStudioId = "1",
                City = "California",
                Name = "Warner Bros",
                RentedFilmCopies = new List<FilmCopy>()
            };


            int NumberOfCopies = 5;
            var filmCopies = new List<FilmCopy>();


            for(int i = 0; i < NumberOfCopies; i++)
            {
                var filmCopy = new FilmCopy
                {
                    FilmCopyId = (i + 1).ToString(),
                    FilmId = "1",
                    RentedOut = false
                };
                filmCopies.Add(filmCopy);
                // add film copy
                db.FilmCopies.Add(filmCopy);
            }

            // rented film copy
            var _filmCopy = new FilmCopy
            {
                FilmCopyId = (NumberOfCopies + 1).ToString(),
                FilmId = "1",
                RentedOut = true,
                FilmStudioId = filmStudio.FilmStudioId,
            };

            filmCopies.Add(_filmCopy);

            // add new film
            db.Films.Add(new Film
            {
                FilmId = "1",
                Name = "The Batman",
                Country = "USA",
                ReleaseDate = new DateTime(2022, 3, 1),
                Director = "Matt Reeves",
                FilmCopies = filmCopies
            });


            filmStudio.RentedFilmCopies.Add(_filmCopy);
            // add new film studio user
            db.Users.Add(new User
            {
                UserId = "2",
                Username = "filmstudion",
                Password = "filmstudion",
                Role = "film studio",
                FilmStudio = filmStudio,
                FilmStudioId = filmStudio.FilmStudioId
            });

            db.FilmCopies.Add(_filmCopy);
            db.FilmStudios.Add(filmStudio);

            // save the changes
            db.SaveChanges();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task<bool>.CompletedTask;
        }

    }
}
