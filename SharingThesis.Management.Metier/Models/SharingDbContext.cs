using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
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
    }
}