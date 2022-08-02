using FilmAPI.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmAPI.api.user
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        readonly FilmDbContext _db;
        private IConfiguration _config;

        public UsersController(FilmDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost("register")]
        public ActionResult<IUser> Register(UserRegister user)
        {
            var existingUser = _db.Users.FirstOrDefault(_user => _user.Username == user.Username);
            if (existingUser != null && existingUser != default(User))
                return Conflict(new
                {
                    Message = "User exists!"
                });
            if (user.Username.Length == 0 || user.Password.Length == 0)
                return BadRequest(new
                {
                    Message = "Username or password not valid"
                });
            string userId = (_db.Users.Count() + 1).ToString();
            var _user = new User { UserId = userId, Username = user.Username, Password = user.Password, Role = "admin" };
            _db.Users.Add(_user);
            _db.SaveChanges();
            return Ok(_user);
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<IUser> Authenticate([FromBody] UserAuthenticate user)
        {
            var username = user.Username;
            var _user = _db.Users.Include(_user=>_user.FilmStudio).ThenInclude(filmstudio=>filmstudio.RentedFilmCopies).FirstOrDefault(_user => user.Username == _user.Username && user.Password == _user.Password);
            if (_user == null || _user == default(User))
            {
                return Unauthorized();
            }
            else
            {
                _user.Token = GenerateToken(_user);
                _db.Update(_user);
                _db.SaveChanges();
                _user.Password = "";
                return Ok(_user);
            }
        }

        private string GenerateToken(IUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audiance"],
                claims,
                expires: DateTime.Now.AddMonths(12),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
