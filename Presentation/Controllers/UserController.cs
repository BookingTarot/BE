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
        public async Task<IActionResult> GetListUser()
        {
            var reponse = await _service.GetAll();
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var reponse = await _service.Login(loginRequest.Email, loginRequest.Password);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }

        [HttpPost("register-customer")]
        public async Task<IActionResult> RegisterCustomer(RegisterRequest registerRequest)
        {
            var reponse = await _service.RegisterCustomer(registerRequest);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPost("register-tarotreader")]
        public async Task<IActionResult> RegisterTarotReader(RegisterTarotReaderRequest registerRequest)
        {
            var reponse = await _service.RegisterTarotReader(registerRequest);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var reponse = await _service.GetById(id);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateUser(UserRequest user)
        {
            var reponse = await _service.Update(user);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPut("{id}/{roleId}")]
        public async Task<IActionResult> UpdateRole(int id, int roleId)
        {
            var reponse = await _service.UpdateRole(id, roleId);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var reponse = await _service.Delete(id);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
    }
}
