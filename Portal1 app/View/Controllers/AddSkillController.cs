using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.MaterialPopulation;

namespace View.Controllers
{
    public static class AddSkillController
    {
        public static async Task AddSkill()
        {
            var skillPopulation = new MaterialPopulationService();
            Console.WriteLine("Add Skills");
            await skillPopulation.PopulateSkill();
        }
    }
}
