using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharingThesis.Management.Metier.Models
{
    public class Memoire
    {
        [Key]
        public int Id { get; set; }

        public int Annee { get; set; }

        public string Nom { get; set; }

        public string Niveau { get; set; }

        public string Description { get; set; }

        public string Etat { get; set; }

        public double NoteFinale { get; set; }

        public string Appreciation { get; set; }

        public string Verdict { get; set; }
    }
}