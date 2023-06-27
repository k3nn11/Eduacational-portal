using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User : EntityBase
    {
        public PersonalInformation PersonalInformation { get; set; }

        public ICollection<Course> CompletedCourses { get; set; }


        public ICollection<Course> InProgressCourses { get; set; }


        public ICollection<Course> NotStartedCourses { get; set; }

        public virtual PersonalInformation Information { get; set; }

        public virtual Login Login { get; set; }
    }
}
