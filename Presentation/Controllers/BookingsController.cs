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
        public async Task<IActionResult> GetBookings([FromQuery] GetListBookingRequest request)
        {
            return Ok(await _service.GetBookings(request));
        }

        [HttpPost()]
        public  async Task<IActionResult> AddBooking([FromBody] BookingRequest booking)
        {
            var response = await  _service.AddBooking(booking);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var response = await _service.DeleteBooking(id);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            return Ok(await _service.GetBooking(id));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingRequest booking)
        {
            var response = await _service.UpdateBooking(booking);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

    }
}
