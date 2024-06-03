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
        public  IActionResult GetListTarot()
        {
            var reponse =  _service.getAll();
            if(reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPost]
        public IActionResult AddTarot([FromBody] TarotReader tarotReader)
        {
            if (_service.Add(tarotReader))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateTarot([FromBody] TarotReader tarotReader)
        {
            if (_service.Update(tarotReader))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTarot(int id)
        {
            if (_service.Delete(id))
            {
                return Ok();
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
