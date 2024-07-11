using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharingThesis.Management.Metier.Models
{
    public class Td_Erreur
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateErreur { get; set; }

        [MaxLength(3000) ,Required]
        public string DescriptionErreur { get; set; }
        [MaxLength(3000), Required]
        public string TitreErreur { get; set; }
    }
}