﻿namespace FilmAPI.Models.FilmStudio
{
    public class RegisterFilmStudio : IRegisterFilmStudio
    {
        public string FilmStudioCity { get; set; }
        public string FilmStudioName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
