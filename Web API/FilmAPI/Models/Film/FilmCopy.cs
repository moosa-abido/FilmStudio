namespace FilmAPI.Models.Film
{
    public class FilmCopy : IFilmCopy
    {
        public string FilmCopyId { get; set; }
        public string FilmId { get; set; }
        public bool RentedOut { get; set; }
        public string? FilmStudioId { get; set; }
    }
}
