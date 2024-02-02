using Data.Generic_interface;
using Data.Models;
using Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CoursesService
{
    public class CourseService : ICourseService
    {
        private readonly static Repository<User> UserRepository = new Repository<User>();

        public CourseService()
        {
            InitializeUserAsync().Wait();
        }

        public User User { get; private set; }

        public async Task<User> GetUserAsync()
        {
            await Console.Out.WriteLineAsync("Enter User Id.");
            int userId = RequestId();
            User user = await UserRepository.GetByID(userId);
            if ( user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task StartCourseAsync()
        {
            Repository<Course> courseRepository = new Repository<Course>();
            await Console.Out.WriteLineAsync("Enter Course ID. ");
            Course course = await courseRepository.GetByID(RequestId());
            //List<Course> list = new List<Course>();
            //User user = await GetUserAsync();
            Repository<User> userRepository = new Repository<User>();
            if (User != null)
            {
                if (!User.CompletedCourses.Contains(course) && !User.InProgressCourses.Contains(course))
                {
                    User.NotStartedCourses.Add(course);
                    Console.WriteLine($"New course enrolled: {course.Title}");
                    await userRepository.Update(User.Id, User);
                    return;
                }

                await Console.Out.WriteLineAsync("Course is already enrolled");
                return;
            }
            else
            {
                await Console.Out.WriteLineAsync("User Id does not exist");
                return;
            }
        }

        public async Task AddInProgressCoursesAsync()
        {
            //var Id = RequestId();
            Repository<User> userRepository = new Repository<User>();
            // if user reads material from the Not started courses, its registered in the InProgress courses.
            //User user = await GetUserAsync();
            if (User != null)
            {
                foreach (var course in User.NotStartedCourses)
                {
                    User.InProgressCourses.Add(course);
                    User.NotStartedCourses.Remove(course);
                    await userRepository.Update(User.Id, User); // checking for errors here.
                    return;
                }
            }
            else
            {
                await Console.Out.WriteLineAsync("User Id does not exist");
            }
        }

        public async Task AddCompletePercentageAsync()
        {
            List<Course> courses = new List<Course>();
            int readCount = default;
            int courseId = default;
            Repository<Course> courseRepository = new Repository<Course>();
            Repository<User> userRepository = new Repository<User>();
            Repository<Article> articleRepository = new Repository<Article>();
            Repository<Book> bookRepository = new Repository<Book>();
            Repository<Video> videoRepository = new Repository<Video>();
            EntryOrder();
            Article article = await articleRepository.GetByID(RequestId());
            Video video = await videoRepository.GetByID(RequestId());
            Book book = await bookRepository.GetByID(RequestId());
            //User user = await GetUserAsync();
            var userId = User.Id;
            if (User != null)
            {
                foreach (var course in User.InProgressCourses)
                {
                    //Repository<User> userRepository = new Repository<User>();
                    int materialCount = course.Articles.Count + course.Articles.Count + course.Videos.Count;
                    if (course.Articles.Contains(article))
                    {
                        await Console.Out.WriteLineAsync(article.Title);
                        course.Articles.Remove(article);
                        readCount++;
                    }
                    else if (course.Books.Contains(book))
                    {
                        await Console.Out.WriteLineAsync(book.Title);
                        course.Books.Remove(book);
                        readCount++;
                    }
                    else if (course.Videos.Contains(video))
                    {
                        await Console.Out.WriteLineAsync(video.Title);
                        course.Videos.Remove(video);
                        readCount++;
                    }

                    int percentage = (readCount / materialCount) * 100;
                    course.CompletionPercentage = percentage;
                    courseId = course.Id;

                    courses.Add(course);
                }

                Course course1 = new Course();
                await courseRepository.Update(courseId, course1); // check for errors.
                await userRepository.Update(userId, User); // check for errors later here.
            }
        }

        public async Task AddCompletedCoursesAsync()
        {
            Repository<User> userRepository = new Repository<User>();
            //User user = await GetUserAsync();
            if ( User != null)
            {
                var userId = User.Id;
                foreach (var course in User.InProgressCourses)
                {
                    if (course.CompletionPercentage == 100)
                    {
                        User.CompletedCourses.Add(course);
                        User.InProgressCourses.Remove(course);
                        await Console.Out.WriteLineAsync($"Success!!!- {course} is completed");
                    }

                    await userRepository.Update(userId, User); // check for errors here
                }
            }
        }

        private static int RequestId()
        {
            ValidationService validationService = new ValidationService();
            Console.WriteLine("Enter Id ");
            int id = validationService.ValidationInterger();
            return id;
        }

        private static void EntryOrder()
        {
            Console.WriteLine("Enter ID of materials in the following order:");
            Console.WriteLine("Article, Video, Book");
        }

        private async Task InitializeUserAsync()
        {
            User = await GetUserAsync();
        }
    }
}
