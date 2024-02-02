﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CoursePopulation
{
    public interface ICoursePopulationService
    {
        Task<List<Course>> PopulateCourseFromSystem();

        Task <List<Course>> PopulateCourseFromUser();
    }
}
