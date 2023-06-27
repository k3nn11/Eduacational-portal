using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Models;
using Services.Validation;

namespace Services.MaterialPopulation
{
    public class MaterialPopulationService : IMaterialPopulationService
    {
        public async Task<List<Article>> PopulateArticle()
        {
            int articleId = 1;
            char answer = default;
            string article = nameof(Article);
            List<Article> articles = new List<Article>();
            var validation = new ValidationService();
            var articleRepository = new Repository<Article>();
            do
            {
                Console.WriteLine(" Enter the information for Article material\nUse the format below");
                Console.WriteLine("Title, description, dateofPublication, resource");
                string title = Console.ReadLine();
                string description = Console.ReadLine();
                DateTime dateOfPublication = validation.ValidationDate();
                string resource = Console.ReadLine();
                articles.Add(new Article() {Id = articleId++, Title = title, Description = description, DateOfPublication = dateOfPublication, Resource = resource });
                Console.WriteLine("SUCCESS! Materials added!");
                answer = validation.OptionValidation(article);
            }
            while (answer == 'Y');
            foreach (var a in articles)
            {
                await articleRepository.Create(a);
            }

            return articles;
        }

        public async Task<List<Book>> PopulateBook()
        {
            int bookId = default;
            string userInput;
            char answer;
            string book = nameof(Book);
            List<Book> books = new List<Book>();
            var validation = new ValidationService();
            do
            {
                Console.WriteLine(" Enter the information for Book material\nUse the format below");
                Console.WriteLine("Title,description, Format, NumberofPages, Authors, YearOfPublication");
                string title = Console.ReadLine();
                string description = Console.ReadLine();
                string format = Console.ReadLine();
                int numberOfPages = validation.ValidationInterger();
                List<string> authors = new List<string>();
                Console.WriteLine("Enter authors to the list ( Enter 'q' when finish)");
                while (true)
                {
                    userInput = Console.ReadLine();
                    if (userInput.ToLower() == "q")
                    {
                        break;
                    }

                    authors.Add(userInput);
                }

                DateTime yearOfPublication = validation.ValidationDate();
                books.Add(new Book {Id = bookId++, Title = title, Description = description, Format = format, NumberOfPages = numberOfPages, Authors = authors, YearOfPublication = yearOfPublication });
                Console.WriteLine("SUCCESS! Material added.");
                answer = validation.OptionValidation(book);
            }
            while (answer == 'y');
            Repository<Book> bookRepository = new Repository<Book>();
            foreach (var b in books)
            {
                await bookRepository.Create(b);
            }

            return books;
        }

        public async Task<List<Video>> PopulateVideo()
        {
            int videoId = 1;
            char answer;
            string video = nameof(Video);
            List<Video> videos = new List<Video>();
            var validation = new ValidationService();
            do
            {
                Console.WriteLine(" Enter the information for Video material\nUse the format below");
                Console.WriteLine("Title, description, Duration, Quality");
                string title = Console.ReadLine();
                string description = Console.ReadLine();
                decimal duration = validation.ValidationDecimal();
                string quality = Console.ReadLine();
                videos.Add(new Video() { Id = videoId++, Title = title, Description = description, Duration = duration, Quality = quality });
                Console.WriteLine("SUCCESS! Material added");
                answer = validation.OptionValidation(video);
            }
            while (answer == 'Y');
            Repository<Video> videoRepository = new Repository<Video>();
            foreach (var v in videos )
            {
                await videoRepository.Create(v);
            }

            return videos;
        }

        public async Task<List<Skill>> PopulateSkill()
        {
            int skillId = 1;
            char answer;
            string skill = nameof(Skill);
            List<Skill> skills = new List<Skill>();
            var validation = new ValidationService();
            do
            {
                Console.WriteLine("Enter Name of skill");
                string title = Console.ReadLine();
                Console.WriteLine("Enter the Description of the skill");
                string description = Console.ReadLine();
                skills.Add(new Skill {Id = skillId++, Title = title, Description = description, Level = 1 });
                Console.WriteLine("Skill Successfully added!");
                answer = validation.OptionValidation(skill);
            }
            while (answer == 'Y');
            Repository<Skill> skillRepository = new Repository<Skill>();
            foreach ( var s in skills )
            {
                await skillRepository.Create(s);
            }

            return skills;
        }

        
    }
}
