using FilmAPI.Models.Film;

namespace FilmAPI.Models.FilmStudio
{
    public class FilmStudio : IFilmStudio
    {
        public string FilmStudioId { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public List<FilmCopy>? RentedFilmCopies { get; set; }
    }
}
