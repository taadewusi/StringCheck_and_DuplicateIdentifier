using Microsoft.AspNetCore.Mvc;
using StringCheck.Models;
using System.Text.Json;
namespace StringCheck.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DuplicateCheckerController : Controller
    {

        [HttpPost("identifyDuplicates")]
        public IActionResult IdentifyDuplicates([FromBody] DuplicateCheckRequest<int> request)
        {
            if (request == null || request.CA == null || request.CS == null)
            {
                return BadRequest("Invalid request. Collections CA and CS must not be null.");
            }

            try
            {
                var identifier = new DuplicateIdentifier<int>();
                var results = identifier.IdentifyDuplicates(request.CA, request.CS);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
