﻿namespace FilmAPI.Models.User
{
    public class UserRegister : IUserRegister
    {
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
