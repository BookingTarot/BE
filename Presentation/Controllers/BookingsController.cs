using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _service;
        public BookingsController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            return Ok(_service.GetBookings());
        }

        [HttpPost]
        public IActionResult AddBooking([FromBody] BookingRequest booking)
        {
            if (_service.AddBooking(booking))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
