using Labb_3_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IInterest _interest;
        public InterestController(IInterest interest)
        {
            _interest = interest;
        }

        [HttpGet("Interests")]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interest.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
    }
}
