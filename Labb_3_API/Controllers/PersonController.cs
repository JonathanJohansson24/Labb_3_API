using Labb_3_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson _person;

        public PersonController(IPerson person)
        {
            _person = person;
        }

        [HttpGet("Persons")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                return Ok(await _person.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
        [HttpGet("GetLinks/{id:int}")]
        public async Task<IActionResult> GetLinks(int id)
        {
            try
            {
                var result = await _person.GetLinksById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data to database");
            }
        }
        [HttpGet("GetInterests/{id:int}")]
        public async Task<IActionResult> GetInterests(int id)
        {
            try
            {
                var result = await _person.GetInterestById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data to database");
            }
        }
        [HttpPost("AddNewInterest/{personId:int}/{interestId:int}")]
        public async Task<IActionResult> AddInterestToPerson(int personId, int interestId)
        {
            try
            {
                var personInterest = await _person.AddNewInterest(personId, interestId);
                if (personInterest == null)
                {
                    return NotFound("Person or interest not found.");
                }
                return Ok(personInterest);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add new interest to database");
            }
        }

    }
}
