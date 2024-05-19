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
    }
}
