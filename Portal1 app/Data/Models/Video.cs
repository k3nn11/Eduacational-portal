using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Video : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal Duration { get; set; }

        public string Quality { get; set; }

    }
}