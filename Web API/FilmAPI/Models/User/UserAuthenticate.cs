namespace FilmAPI.Models.User
{
    public class UserAuthenticate : IUserAuthenticate
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
