using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        public DocumentController()
        {

        }

        [HttpGet("getDocument")]
        public async Task<IActionResult> GetDocument()
        {
            return Ok();
        }

        [HttpPost("postDocument")]
        public async Task<IActionResult> PostDocument()
        {
            return Ok();
        }
    }
}
