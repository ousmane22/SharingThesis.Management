using MySql.Data.EntityFramework;
using SharingThesis.Management.Metier.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SharingThesis.Management.Metier.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SharingDbContext : DbContext
    {
        public SharingDbContext() : base("SharingThesisContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Commentaire> Comments { get; set; }
        public DbSet<Td_Erreur> Errors { get; set; }
        public DbSet<Memoire> Memories { get; set; }
        public DbSet<Expert> Experts { get; set; }
    }
}