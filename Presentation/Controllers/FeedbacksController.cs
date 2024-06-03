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
        public IActionResult AddFeedback([FromBody] Feedback feedback)
        {
            if (_service.AddFeedback(feedback))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateFeedback([FromBody] Feedback feedback)
        {
            if (_service.UpdateFeedback(feedback))
            {
                return Ok();
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
