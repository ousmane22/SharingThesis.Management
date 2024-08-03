using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SharingThesis.Management.Metier.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        public string Extension { get; set; }

        public string Nom { get; set; }
    }
}