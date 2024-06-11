using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;

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

        [HttpPost()]
        public  IActionResult AddBooking([FromBody] BookingRequest booking)
        {
            var response =  _service.AddBooking(booking);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var response = _service.DeleteBooking(id);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            return Ok(_service.GetBooking(id));
        }
        [HttpPut]
        public IActionResult UpdateBooking([FromBody] BookingRequest booking)
        {
            var response = _service.UpdateBooking(booking);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

    }
}
