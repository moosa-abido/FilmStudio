using FilmAPI.Models.Film;

namespace FilmAPI.Models.FilmStudio
{

    public interface IFilmStudio
    {
        public string FilmStudioId { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public List<FilmCopy>? RentedFilmCopies { get; set; }
    }
}