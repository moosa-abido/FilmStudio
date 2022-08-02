
namespace FilmAPI.Models.User
{
    public interface IUser
    {
        public string UserId { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? FilmStudioId { get; set; }
        public FilmStudio.FilmStudio? FilmStudio { get; set; }
        public string? Token { get; set; }
    }
}