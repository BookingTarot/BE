using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
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

        [HttpGet()]
        public IActionResult GetListUser()
        {
            var reponse = _service.GetAll();
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var reponse = _service.Login(loginRequest.Email, loginRequest.Password);
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

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var reponse = _service.GetById(id);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPut()]
        public IActionResult UpdateUser(UserRequest user)
        {
            var reponse = _service.Update(user);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var reponse = _service.Delete(id);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
    }
}
