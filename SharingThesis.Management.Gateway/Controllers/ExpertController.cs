using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharingThesis.Management.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        private readonly ServiceMetier.Service1Client _service = new ServiceMetier.Service1Client();

        [HttpPost]
        public async Task<IActionResult> AddExpert([FromBody] ServiceMetier.Expert expert)
        {
            if (expert == null)
            {
                return BadRequest("Expert is null.");
            }

            bool result = await _service.AddExpertAsync(expert);
            if (result)
            {
                return Ok(new { message = "Expert added successfully." });
            }
            else
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpertById(int id)
        {
            ServiceMetier.Expert expert = await _service.GetExpertByIdAsync(id);
            if (expert == null)
            {
                return NotFound("Expert not found.");
            }

            return Ok(expert);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpert([FromBody] ServiceMetier.Expert expert)
        {
            if (expert == null)
            {
                return BadRequest("Expert is null.");
            }

            bool result = await _service.UpdateExpertAsync(expert);
            if (result)
            {
                return Ok("Expert updated successfully.");
            }
            else
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpert(int id)
        {
            bool result = await _service.DeleteExpertAsync(id);

            if (result)
            {
                return Ok(new { message = "Expert deleted successfully." });
            }
            else
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExperts()
        {
            ServiceMetier.Expert[] expertsArray = await _service.GetAllExpertsAsync();
            List<ServiceMetier.Expert> expertsList = expertsArray.ToList();
            return Ok(expertsList);
        }
    }
}
