using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SharingThesis.Management.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ServiceMetier.Service1Client _service = new ServiceMetier.Service1Client();


        [HttpGet]
        public async Task<IActionResult> GetAllExperts()
        {
            ServiceMetier.Td_Erreur[] logsArray = await _service.GetLogsAsync();
            List<ServiceMetier.Td_Erreur> logsList = logsArray.ToList();
            return Ok(logsList);
        }
    }
}
