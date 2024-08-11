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
        public  async Task<IActionResult> GetListTarot([FromQuery]GetListTarotReaderRequest request)
        {
            var reponse = await  _service.getAll(request);
            if(reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        [HttpPost]
        public async Task<IActionResult> AddTarot([FromBody] TarotReaderRequest tarotReader)
        {
            var response = await _service.Add(tarotReader);
            if (response == true)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPost("addSessionType")]
        public async Task<IActionResult> AddSessionTypeToTarotReader([FromBody] SessionTypeToTarotReaderRequest sessionTypeToTarotReader)
        {
            
            if (await _service.AddSessionTypeToTarotReader(sessionTypeToTarotReader))
            {
                return Ok("Successfull!");
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTarot([FromBody] TarotReaderRequest tarotReader)
        {
            var response = await _service.Update(tarotReader);
            if (response == true)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarot(int id)
        {
            var response = await _service.Delete(id);
            if (response == true)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarotReaderById(int id)
        {
            var reponse = await _service.getTarotReaderById(id);
            if (reponse == null)
            {
                return NotFound();
            }
            return Ok(reponse);
        }
        
    }
}
