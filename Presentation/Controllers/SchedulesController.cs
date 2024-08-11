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
        public async Task<IActionResult> GetSchedules()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("tarot/{tarotReaderId}")]
        public async Task<IActionResult> GetSchedulesByTarotReaderId(int tarotReaderId)
        {
            return Ok(await _service.GetSchedulesByTarotReaderId(tarotReaderId));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            return Ok(await _service.GetScheduleById(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddSchedule([FromBody] ScheduleRequest schedule)
        {
            var response = await _service.AddSchedule(schedule);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSchedule([FromBody] ScheduleRequest schedule)
        {
            var response = await _service.UpdateSchedule(schedule);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            if (await _service.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        


    }
}
