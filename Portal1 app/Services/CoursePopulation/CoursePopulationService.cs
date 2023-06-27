using Data.Generic_interface;
using Data.Models;
using Services.MaterialPopulation;
using Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CoursePopulation
{
    public class CoursePopulationService : ICoursePopulationService
    {
        public async Task<List<Course>> PopulateCourseFromSystem()
        {
            int courseId = 1;
            ValidationService validation = new ValidationService();
            List<Course> courses = new List<Course>();
            string coursename = nameof(Course);
            char answer = default;
            List<Article> articles = new List<Article>();
            List<Book> books = new List<Book>();
            List<Video> videos = new List<Video>();
            List<Skill> skills = new List<Skill>();
            do
            {
                Console.WriteLine(" Enter the information for Course material\nUse the format below");
                Console.WriteLine("Title, description, Skill, type of material");
                string title = Console.ReadLine();
                string description = Console.ReadLine();
                Repository<Skill> repository = new Repository<Skill>();
                Console.WriteLine("Enter Skill ID");
                int skillId = validation.ValidationInterger();
                Skill skill = await repository.GetByID(skillId);
                //List<Skill> skills = PopulateSkill();
                MaterialOptions();
                while (true)
                {
                    bool isValid = int.TryParse(Console.ReadLine(), out int input);
                    if (isValid)
                    {
                        if (input == 4)
                        {
                            break;
                        }

                        switch (input)
                        {
                            case 1:
                                Repository<Article> articleRepository = new Repository<Article>();
                                Console.WriteLine("Enter Article ID");
                                int articleId = validation.ValidationInterger();
                                Article article = await articleRepository.GetByID(articleId);
                                articles.Add(article);
                                Console.WriteLine("Article successfully added");
                                break;
                            case 2:
                                Console.WriteLine("Enter Book ID");
                                int bookId = validation.ValidationInterger();
                                Repository<Book> bookRepository = new Repository<Book>();
                                Book book = await bookRepository.GetByID(bookId);
                                books.Add(book);
                                Console.WriteLine("Book successfully added");
                                break;
                            case 3:
                                Console.WriteLine("Enter Video ID");
                                int videoId = validation.ValidationInterger();
                                Repository<Video> videoRepository = new Repository<Video>();
                                Video video = await videoRepository.GetByID(videoId);
                                videos.Add(video);
                                Console.WriteLine("Video successfully added");
                                break;
                            default:
                                Console.WriteLine("Enter a valid input: 1, 2, or 3");
                                continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid input");
                        continue;
                    }
                }

                courses.Add(new Course { Id = courseId++, Title = title, Description = description, Skills = skills, Videos = videos, Articles = articles, Books = books });
                answer = validation.OptionValidation(coursename);
            }
            while (answer == 'Y');
            Repository<Course> courseRepository = new Repository<Course>();
            foreach (var c in courses)
            {
                await courseRepository.Create(c);
            }

            return courses;
        }

        public async Task<List<Course>> PopulateCourseFromUser()
        {
            int courseId = 1;
            ValidationService validation = new ValidationService();
            List<Course> courses = new List<Course>();
            string coursename = nameof(Course);
            char answer = default;
            List<Article> articles = new List<Article>();
            List<Book> books = new List<Book>();
            List<Video> videos = new List<Video>();
            do
            {
                Console.WriteLine(" Enter the information for Course material\nUse the format below");
                Console.WriteLine("Title, Description, Skill, Type of material");
                string title = Console.ReadLine();
                string description = Console.ReadLine();
                MaterialPopulationService materialPopulation = new MaterialPopulationService();
                List<Skill> skills = await materialPopulation.PopulateSkill();
                MaterialOptions();
                bool isValid = int.TryParse(Console.ReadLine(), out int input);
                if (isValid)
                {
                    if (input == 4)
                    {
                        break;
                    }

                    switch (input)
                    {
                        case 1:

                            articles = await materialPopulation.PopulateArticle();
                            Console.WriteLine("Article successfully added");
                            break;
                        case 2:
                            books = await materialPopulation.PopulateBook();
                            Console.WriteLine("Book successfully added");
                            break;
                        case 3:
                            videos = await materialPopulation.PopulateVideo();
                            Console.WriteLine("Video successfully added");
                            break;
                        default:
                            Console.WriteLine("Enter a valid input: 1,2, or 3");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid input: 1, 2, 3 or 4");
                    continue;
                }

                courses.Add(new Course { Id = courseId++, Title = title, Description = description, Skills = skills, Articles = articles, Books = books, Videos = videos });
                answer = validation.OptionValidation(coursename);
            }
            while (answer == 'Y');
            Repository<Course> courseRepository = new Repository<Course>();
            foreach (var c in courses)
            {
                courseRepository.Create(c);
            }

            return courses;
        }

        private static void MaterialOptions()
        {
            Console.WriteLine("Enter type of material you would like to add (Press 4 to exit when done)");
            Console.WriteLine("1: Article material");
            Console.WriteLine("2: Book material");
            Console.WriteLine("3: Video material");
        }
    }
}
