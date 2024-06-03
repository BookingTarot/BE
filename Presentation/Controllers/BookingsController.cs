using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
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

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            if (_service.DeleteBooking(id))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            return Ok(_service.GetBooking(id));
        }
        [HttpPut]
        public IActionResult UpdateBooking([FromBody] Booking booking)
        {
            if (_service.UpdateBooking(booking))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
