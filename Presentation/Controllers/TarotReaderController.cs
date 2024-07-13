using BusinessObjects.DTOs.Request;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarotReaderController : ControllerBase
    {
        private readonly ITarotReaderService _service;

        public TarotReaderController(ITarotReaderService service)
        {
            _service = service;
        }

        [HttpGet()]
        public  IActionResult GetListTarot([FromQuery]GetListTarotReaderRequest request)
        {
            var reponse =  _service.getAll(request);
            if(reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPost]
        public IActionResult AddTarot([FromBody] TarotReaderRequest tarotReader)
        {
            var response = _service.Add(tarotReader);
            if (response == true)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPost("addSessionType")]
        public IActionResult AddSessionTypeToTarotReader([FromBody] SessionTypeToTarotReaderRequest sessionTypeToTarotReader)
        {
            
            if (_service.AddSessionTypeToTarotReader(sessionTypeToTarotReader))
            {
                return Ok("Successfull!");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateTarot([FromBody] TarotReaderRequest tarotReader)
        {
            var response = _service.Update(tarotReader);
            if (response == true)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTarot(int id)
        {
            var response = _service.Delete(id);
            if (response == true)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetTarotReaderById(int id)
        {
            var reponse = _service.getTarotReaderById(id);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        
    }
}
