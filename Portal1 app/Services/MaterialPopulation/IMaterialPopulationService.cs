using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Services.MaterialPopulation
{
    public interface IMaterialPopulationService
    {
        Task<List<Article>> PopulateArticle();

        Task<List<Video>> PopulateVideo();

        Task<List<Book>> PopulateBook();

        Task<List<Skill>> PopulateSkill();
    }
}
