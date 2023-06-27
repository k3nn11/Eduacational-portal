using System;
using Data.Models;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data.DbInitializer
{
    public class LoginConfiguration : EntityTypeConfiguration<Login>
    {
        public LoginConfiguration() 
        {
            //HasKey(x => x.Id);
            ToTable(typeof(Login).Name);
        }

    }
}
