using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _service;
        public SchedulesController(IScheduleService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetSchedules()
        {
            return Ok(_service.GetAll());
        }
        [HttpGet("tarot/{tarotReaderId}")]
        public IActionResult GetSchedulesByTarotReaderId(int tarotReaderId)
        {
            return Ok(_service.GetSchedulesByTarotReaderId(tarotReaderId));
        }
        [HttpGet("{id}")]
        public IActionResult GetSchedule(int id)
        {
            return Ok(_service.GetScheduleById(id));
        }
        [HttpPost]
        public IActionResult AddSchedule([FromBody] ScheduleRequest schedule)
        {
            var response = _service.AddSchedule(schedule);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateSchedule([FromBody] ScheduleRequest schedule)
        {
            var response = _service.UpdateSchedule(schedule);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSchedule(int id)
        {
            if (_service.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        


    }
}
