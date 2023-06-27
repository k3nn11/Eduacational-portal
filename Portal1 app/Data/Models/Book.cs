using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Book : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public List<string> Authors { get; set; }

        public int NumberOfPages { get; set; }

        public string Format { get; set; }

        public DateTime YearOfPublication { get; set; }

    }

}
