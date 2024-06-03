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
        public IActionResult AddSchedule([FromBody] Schedule schedule)
        {
            if (_service.AddSchedule(schedule))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateSchedule([FromBody] Schedule schedule)
        {
            if (_service.UpdateSchedule(schedule))
            {
                return Ok();
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
