using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amanydb.classes
{
    public class db:DbContext
    {
        public DbSet<Searchrecord> searchrecord { get; set; }
        public DbSet<file> file { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=MOHAMEDYASSER\SQLEXPRESS;Database=amany;TrustServerCertificate=True;Trusted_Connection=True");
         }
    }
}
