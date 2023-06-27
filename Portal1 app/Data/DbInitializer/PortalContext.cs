using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Data.DbInitializer
{
    public class PortalContext : DbContext
    {
        public PortalContext() : base ("Educational Portal")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PortalContext, Migrations.Configuration>());
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PersonalInformation>()
            //.HasRequired(pi => pi.Users)
            //.WithOptional(u => u.Information)
            //.Map(m => m.MapKey("User_Id"));
        }
    }
}
