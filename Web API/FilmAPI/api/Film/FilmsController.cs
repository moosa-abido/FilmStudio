using FilmAPI.Models.Film;
using FilmAPI.Models.FilmStudio;
using FilmAPI.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace FilmAPI.api.film
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        readonly FilmDbContext _db;

        public FilmsController(FilmDbContext db)
        {
            _db = db;
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public ActionResult<Film> AddFilm([FromBody] CreateFilm film)
        {
            var existingFilm = _db.Films.FirstOrDefault(_film => _film.Name == film.Name);
            if (existingFilm != null && existingFilm != default(Film))
                return Conflict(new
                {
                    Message = "Film exists!"
                });
            var user = GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var filmId = (_db.Films.Count() + 1).ToString();
            var filmCopies = new List<FilmCopy>();
            for (int i = 0; i < film.NumberOfCopies; i++)
            {
                var filmCopy = new FilmCopy
                {
                    FilmCopyId = (_db.FilmCopies.Count() + 1 + i).ToString(),
                    FilmId = filmId,
                    RentedOut = false,
                };
                filmCopies.Add(filmCopy);
                
            }
            
            var _film = new Film
            {
                FilmId = filmId,
                Name = film.Name,
                Country = film.Country,
                Director = film.Director,
                ReleaseDate = film.ReleaseDate,
                FilmCopies = filmCopies
            };
            _db.Films.Add(_film);
            _db.SaveChanges();
            return Ok(_film);
        }


        [HttpPut("{id}"), HttpPatch("{id}"), HttpPost("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<Film> UpdateFilm(int id, [FromBody] JsonPatchDocument<Film> patchedFilm)
        {
            var user = GetCurrentUser();
            if (user == null)
                return Unauthorized();
            var film = _db.Films.FirstOrDefault(_film => _film.FilmId == id.ToString());
            if (film == null || film == default(Film))
                return NotFound();
            patchedFilm.ApplyTo(film, ModelState);
            _db.Films.Update(film);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IEnumerable<IFilm> Get()
        {
            
            var user = GetCurrentUser();
            if (user == null)
            {
                return _db.Films.AsEnumerable();
            }
            else
            {
                return _db.Films.Include(film=>film.FilmCopies).AsEnumerable();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IFilm> Get(int id)
        {
            var user = GetCurrentUser();
            if (user == null || user == default(User))
            {
                return _db.Films.Where(film => film.FilmId == id.ToString()).FirstOrDefault();
            }
            else
            {
                return _db.Films.Where(film => film.FilmId == id.ToString()).Include(film => film.FilmCopies).FirstOrDefault();
            }
        }

        [HttpPost("rent")]
        public ActionResult<IFilmCopy> Rent(string id, string studioId)
        {
            var user = GetCurrentUser();
            if (user == null || user.FilmStudioId != studioId)
                return Unauthorized();
            var film = _db.Films.FirstOrDefault(film => film.FilmId == id);
            if(film == default(Film))
                return Conflict(new
                {
                    Message = "Movie is not available!"
                });
            var filmCopy = _db.FilmCopies.FirstOrDefault(filmCopy => filmCopy.FilmId == id && !filmCopy.RentedOut);
            if (filmCopy == default(FilmCopy))
                return Conflict(new
                {
                    Message = "Movie has no free copies!"
                });
            
            var filmstudio = user.FilmStudio;
            if (filmstudio == null)
                return Unauthorized();

            if (filmstudio.RentedFilmCopies != null && filmstudio.RentedFilmCopies.Find(_filmCopy => _filmCopy.FilmId == id) != null)
                return StatusCode((int)HttpStatusCode.Forbidden, new
                {
                    Message = "Film copy is already rented!"
                });

            // update the filmCopy studio rented filmCopy copies
            if (filmstudio.RentedFilmCopies == null)
                filmstudio.RentedFilmCopies = new List<FilmCopy>();
            filmstudio.RentedFilmCopies.Add(filmCopy);
            _db.FilmStudios.Update(filmstudio);

            // update the filmCopy rented copies
            filmCopy.FilmStudioId = studioId;
            filmCopy.RentedOut = true;
            _db.FilmCopies.Update(filmCopy);
            _db.SaveChanges();
            return Ok(filmCopy);
        }

        [HttpPost("return")]
        public ActionResult<IFilmCopy> Return(string id, string studioId)
        {
            var user = GetCurrentUser();
            if (user == null || user.FilmStudioId != studioId)
                return Unauthorized();
            var filmCopy = _db.FilmCopies.FirstOrDefault(filmCopy => filmCopy.FilmId == id && filmCopy.RentedOut && filmCopy.FilmStudioId == studioId);
            if (filmCopy == default(FilmCopy))
                return Conflict(
                    new
                    {
                        Message = "Film copy is already returned!"
                    });

            var filmstudio = user.FilmStudio;

            // update film studio rented copies
            filmstudio?.RentedFilmCopies?.RemoveAll(copy => copy.FilmStudioId == studioId && copy.RentedOut && copy.FilmId == id);

            _db.FilmStudios.Update(filmstudio);

            filmCopy.FilmStudioId = "";
            filmCopy.RentedOut = false;
            _db.FilmCopies.Update(filmCopy);
            _db.SaveChanges();
            return Ok();
        }



        private IUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var userId = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;

                var user = _db.Users.Include(user => user.FilmStudio).ThenInclude(filmstudio=>filmstudio.RentedFilmCopies).FirstOrDefault(user => user.UserId == userId);
                return user == default(User) ? null : user;
            }
            return null;
        }
    }
}
