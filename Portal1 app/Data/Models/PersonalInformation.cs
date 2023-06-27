using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PersonalInformation : EntityBase
    {

        public string Name { get; set; }

        public List<Skill> Skills { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}
