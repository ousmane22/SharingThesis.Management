using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharingThesis.Management.Gateway.Controllers
{
    // L'attribut [Authorize] signifie que tous les endpoints de ce contrôleur nécessitent une authentification.
    [Authorize]
    // L'attribut [Route] définit la route de base pour ce contrôleur.
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController : ControllerBase
    {
        // Déclaration du client de service métier pour les opérations liées aux experts.
        private readonly ServiceMetier.Service1Client _service = new ServiceMetier.Service1Client();

        // Endpoint pour ajouter un nouvel expert.
        [HttpPost]
        public async Task<IActionResult> AddExpert([FromBody] ServiceMetier.Expert expert)
        {
            // Vérification si l'objet expert est null.
            if (expert == null)
            {
                return BadRequest("Expert is null.");
            }

            // Appel du service pour ajouter l'expert.
            bool result = await _service.AddExpertAsync(expert);
            if (result)
            {
                return Ok(new { message = "Expert added successfully." });
            }
            else
            {
                // Retourne un code 500 si une erreur s'est produite lors du traitement de la demande.
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        // Endpoint pour obtenir un expert par son ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpertById(int id)
        {
            // Appel du service pour obtenir l'expert par ID.
            ServiceMetier.Expert expert = await _service.GetExpertByIdAsync(id);
            if (expert == null)
            {
                return NotFound("Expert not found.");
            }

            return Ok(expert);
        }

        // Endpoint pour mettre à jour un expert existant.
        [HttpPut]
        public async Task<IActionResult> UpdateExpert(int id, [FromBody] ServiceMetier.Expert expert)
        {
            // Vérification si l'objet expert est null.
            if (expert == null)
            {
                return BadRequest("Expert ID mismatch");
            }

            // Appel du service pour mettre à jour l'expert.
            bool result = await _service.UpdateExpertAsync(expert);
            if (result)
            {
                return Ok(new { message = "Expert updated successfully." });
            }
            else
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        // Endpoint pour supprimer un expert par son ID.
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

        // Endpoint pour obtenir tous les experts.
        [HttpGet]
        public async Task<IActionResult> GetAllExperts()
        {
            // Appel du service pour obtenir tous les experts.
            ServiceMetier.Expert[] expertsArray = await _service.GetAllExpertsAsync();
            // Conversion du tableau d'experts en liste, triée par ID décroissant.
            List<ServiceMetier.Expert> expertsList = expertsArray.OrderByDescending(e => e.Id).ToList();
            return Ok(expertsList);
        }
    }
}
