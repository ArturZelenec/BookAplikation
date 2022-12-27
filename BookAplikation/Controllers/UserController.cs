using BookAplikation.Models.DTO;
using BookAplikation.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAplikation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var loginResponse = _userRepo.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest(new { mesage = "Username or password is incorect" });
            }
            return Ok(loginResponse);
        }

        [HttpPost("Registration")]
        public IActionResult Register([FromBody] RegistrationRequest model)
        {

            if (!_userRepo.IsUniqueUser(model.Username))
            {
                return BadRequest(new { mesage = "Username already exists" });
            }

            var user = _userRepo.Register(model);
            if (user == null)
            {
                return BadRequest(new { mesage = "Registration failed" });
            }
            return Ok(user);
        }
    }
}
