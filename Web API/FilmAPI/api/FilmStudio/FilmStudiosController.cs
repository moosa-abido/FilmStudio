using FilmAPI.Models.Film;
using FilmAPI.Models.FilmStudio;
using FilmAPI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FilmAPI.api.filmstudio
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmStudiosController : ControllerBase
    {
        readonly FilmDbContext _db;

        public FilmStudiosController(FilmDbContext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public ActionResult<IFilmStudio> Register(RegisterFilmStudio studio)
        {
            var existingUser = _db.Users.FirstOrDefault(user => user.Username == studio.Username);
            if (existingUser != null && existingUser != default(User))
                return Conflict(new
                {
                    Message = "User exists!"
                });
            if (studio.Username.Length == 0 || studio.Password.Length == 0)
                return BadRequest(new
                {
                    Message = "Please fill in the input fields!"
                });
            var studioId = (_db.FilmStudios.Count() + 1).ToString();
            var filmStudio = new FilmStudio { FilmStudioId = studioId, Name = studio.FilmStudioName, City = studio.FilmStudioCity };
            var userId = (_db.Users.Count() + 1).ToString();
            var user = new User
            {
                UserId = userId,
                FilmStudio = filmStudio,
                FilmStudioId = studioId,
                Username = studio.Username,
                Password = studio.Password,
                Role = "film studio",
            };
            _db.Users.Add(user);
            _db.FilmStudios.Add(filmStudio);
            _db.SaveChanges();
            return Ok(filmStudio);
        }

        [HttpGet]
        public IEnumerable<IFilmStudio> Get()
        {
            var user = GetCurrentUser();
            if(user == null || user.Role != "admin")
            {
                return _db.FilmStudios.Select(studio => new FilmStudio { FilmStudioId = studio.FilmStudioId, Name = studio.Name }).AsEnumerable();
            }
            else
            {
                return _db.FilmStudios.AsEnumerable();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IFilmStudio> Get(int id)
        {
            
            var user = GetCurrentUser();
            if (user == null || user.Role != "admin")
            {
                return _db.FilmStudios.Where(studio => studio.FilmStudioId == id.ToString()).Select(studio => new FilmStudio { FilmStudioId = studio.FilmStudioId, Name = studio.Name }).FirstOrDefault();
            }
            else
            {
                return _db.FilmStudios.Where(studio => studio.FilmStudioId == id.ToString()).FirstOrDefault();
            }
        }

        [HttpGet, Route("~/api/mystudio/rentals")]
        public ActionResult<IFilmCopy> Rentals()
        {
            var user = GetCurrentUser();
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var result = _db.FilmCopies.Where(filmCopy => filmCopy.FilmStudioId == user.FilmStudioId);
                return Ok(result);
            }
        }


        private IUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var userId = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;

                var user = _db.Users.Include(user => user.FilmStudio).ThenInclude(filmstudio => filmstudio.RentedFilmCopies).FirstOrDefault(user => user.UserId == userId);
                return user == default(User) ? null : user;
            }
            return null;
        }
    }
}
