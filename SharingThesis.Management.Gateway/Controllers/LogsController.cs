using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharingThesis.Management.Gateway.Controllers
{
    /// <summary>
    /// Contrôleur pour gérer les opérations liées aux logs.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        // Déclaration du client de service métier pour les opérations liées aux logs.
        private readonly ServiceMetier.Service1Client _service = new ServiceMetier.Service1Client();

        /// <summary>
        /// Obtient tous les logs d'erreurs.
        /// </summary>
        /// <returns>Liste de logs d'erreurs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            // Appel du service pour obtenir tous les logs.
            ServiceMetier.Td_Erreur[] logsArray = await _service.GetLogsAsync();
            // Conversion du tableau de logs en liste.
            List<ServiceMetier.Td_Erreur> logsList = logsArray.ToList();
            return Ok(logsList);
        }
    }
}
