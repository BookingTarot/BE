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
        public IActionResult GetFeedbacksByTarotReaderId(int tarotReaderId)
        {
            return Ok(_service.GetFeedbacksByTarotReaderId(tarotReaderId));
        }

        [HttpGet]
        public IActionResult GetFeedbacks()
        {
            return Ok(_service.GetFeedbacks());
        }
        [HttpGet("{id}")]
        public IActionResult GetFeedbackById(int id)
        {
            return Ok(_service.GetFeedbackById(id));
        }

        [HttpPost]
        public IActionResult AddFeedback([FromBody] FeedBackRequest feedback)
        {
            var response = _service.AddFeedback(feedback);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFeedback(int id,[FromBody] FeedBackRequest feedback)
        {
            var response = _service.UpdateFeedback(id, feedback);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteFeedback(int id)
        {
            if (_service.DeleteFeedback(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
