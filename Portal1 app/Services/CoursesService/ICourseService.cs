using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CoursesService
{
    public interface ICourseService
    {
        Task StartCourseAsync();

        Task AddInProgressCoursesAsync();

        Task AddCompletePercentageAsync();

        Task AddCompletedCoursesAsync();

    }
}
