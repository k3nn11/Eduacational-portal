using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Course : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        [DefaultValue(true)]
        public int CompletionPercentage { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<Video> Videos { get; set; }

        public ICollection<Article> Articles { get; set; }

        public ICollection<Book> Books { get; set; }
    }

}
