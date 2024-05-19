using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var reponse = _service.Login(loginRequest.Email,loginRequest.Password);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var reponse = _service.Register(registerRequest);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
    }
}
