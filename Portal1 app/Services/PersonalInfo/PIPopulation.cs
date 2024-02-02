using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Models;
using Services.CoursesService;

namespace Services.PersonalInfo
{
    public class PIPopulation : IPIPopulation
    {
        private Repository<PersonalInformation> _repository = new Repository<PersonalInformation>();

        public async Task PersonalInfoPopulation()
        {
            PersonalInformation information = new PersonalInformation();
            await Console.Out.WriteLineAsync("Enter name: ");
            string name = Console.ReadLine();
            information.Name = name;
            await _repository.Create(information);
        }

        public async Task SkillPopulation()
        {
            var personalInfo = new PersonalInformation();
            CourseService service = new CourseService();
            User user = service.User;
            if (user != null)
            {
                if (user.CompletedCourses != null)
                {
                    foreach (var course in user.CompletedCourses)
                    {
                        foreach (var skill in course.Skills)
                        {
                            user.Information.Skills.Add(skill);
                            await _repository.Create(personalInfo);
                            await Console.Out.WriteLineAsync($"- {skill} added to user skills");
                        }
                    }

                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
