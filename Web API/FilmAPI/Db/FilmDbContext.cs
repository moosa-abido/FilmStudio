using FilmAPI.Models.Film;
using FilmAPI.Models.FilmStudio;
using FilmAPI.Models.User;
using Microsoft.EntityFrameworkCore;

public class FilmDbContext: DbContext
{
    public FilmDbContext(DbContextOptions<FilmDbContext> options): base(options)
    {
    } 

    public DbSet<User> Users { get; set; }

    public DbSet<Film> Films { get; set; }

    public DbSet<FilmCopy> FilmCopies { get; set; }

    public DbSet<FilmStudio> FilmStudios { get; set; }

}