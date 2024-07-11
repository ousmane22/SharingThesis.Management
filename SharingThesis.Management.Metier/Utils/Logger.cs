using SharingThesis.Management.Metier.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SharingThesis.Management.Metier.Utils
{
    public class Logger
    {
        SharingDbContext db = new SharingDbContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TitreErreur"></param>
        /// <param name="erreur"></param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                Td_Erreur log = new Td_Erreur();
                log.DateErreur = DateTime.Now;
                log.DescriptionErreur = erreur.Length > 1000 ? erreur.Substring(0, 1000) : erreur;
                log.TitreErreur = TitreErreur;
                db.Errors.Add(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }
        }

        /// <summary>
        /// cette méthode enregistre les logs au niveau du système d'exploitation
        /// </summary>
        /// <param name="libelle"></param>
        /// <param name="erreur"></param>
        public static void WriteLogSystem(string libelle, string erreur)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Shared Memory M1gl";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, erreur: {2}", DateTime.Now, libelle, erreur));
            }
        }
    }

}

