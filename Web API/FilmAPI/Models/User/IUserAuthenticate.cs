namespace FilmAPI.Models.User
{
    public interface IUserAuthenticate
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
