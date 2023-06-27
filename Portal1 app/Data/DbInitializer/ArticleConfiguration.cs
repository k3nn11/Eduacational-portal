using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DbInitializer
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration() 
        {
            //HasKey(x => x.Id);
            ToTable(typeof(Article).Name);
        }

    }
}
