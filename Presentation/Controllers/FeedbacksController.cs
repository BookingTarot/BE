using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbacksController(IFeedbackService service)
        {
            _service = service;
        }

        [HttpGet("tarotreader/{tarotReaderId}")]
        public async Task<IActionResult> GetFeedbacksByTarotReaderId(int tarotReaderId)
        {
            return Ok(await _service.GetFeedbacksByTarotReaderId(tarotReaderId));
        }

        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            return Ok(await _service.GetFeedbacks());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            return Ok(await _service.GetFeedbackById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] FeedBackRequest feedback)
        {
            var response = await _service.AddFeedback(feedback);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedback(int id,[FromBody] FeedBackRequest feedback)
        {
            var response = await _service.UpdateFeedback(id, feedback);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var response = await _service.DeleteFeedback(id);
            if (response == true)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
