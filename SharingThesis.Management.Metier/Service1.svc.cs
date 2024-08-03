using SharingThesis.Management.Metier;
using SharingThesis.Management.Metier.Models;
using SharingThesis.Management.Metier.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SharingThesis.Management.Metier
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private readonly SharingDbContext db = new SharingDbContext();
        private readonly Logger _logger = new Logger();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expert"></param>
        /// <returns></returns>
        public bool AddExpert(Expert expert)
        {
            try
            {
                db.Experts.Add(expert);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteDataError("AddExpert", $"Error adding expert: {expert}, Exception: {ex}");
                return false;
            }
        }

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Expert GetExpertById(int id)
        {
            try
            {
                var expert = db.Experts.Find(id);
                if (expert == null)
                {
                    _logger.WriteDataError("GetExpertById", $"Expert not found with ID: {id}");
                    return null;
                }
                return expert;
            }
            catch (Exception ex)
            {
                _logger.WriteDataError("GetExpertById", $"Error retrieving expert with ID: {id}, Exception: {ex}");
                return null;
            }
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteExpert(int id)
        {
            var expert = GetExpertById(id);
            if (expert == null)
            {
                _logger.WriteDataError("DeleteExpert", $"Expert not found for deletion with ID: {id}");
                return false;
            }

            try
            {
                db.Experts.Remove(expert);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteDataError("DeleteExpert", $"Error deleting expert with ID: {id}, Exception: {ex}");
                return false;
            }
        }

        public List<Expert> GetAllExperts()
        {
            return db.Experts.ToList();
        }

        public List<Td_Erreur> GetLogs()
        {
            return db.Errors.ToList();
        }

        public bool UpdateExpert(Expert expert)
        {

            var selectedExpert = db.Experts.Find(expert.Id);

            if (selectedExpert == null)
            {
                _logger.WriteDataError("UpdateExpert", $"Expert not found for update with ID: {expert.Id}");
                return false;
            }

            try
            {
                selectedExpert.FirstName = expert.FirstName;
                selectedExpert.LastName = expert.LastName;
                selectedExpert.Email = expert.Email;
                selectedExpert.Matricule = expert.Matricule;
                selectedExpert.Password = expert.Password;
                selectedExpert.Phone = expert.Phone;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.WriteDataError("UpdateExpert", $"Error updating expert: {expert}, Exception: {ex}");
                return false;
            }
        }
    }
}
