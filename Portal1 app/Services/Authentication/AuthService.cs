using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Generic_interface;
using Data.Generic_interface;
using Data.Models;

namespace Services.Authentication
{
    public class AuthService : IAuthService
    {
        public void CreateUser()
        {
            var login = new Login();
            while (true)
            {
                Console.WriteLine("Enter UserName to sign up:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Password to sign up:");
                string password = Console.ReadLine();
                if (password != null && username != null)
                {
                    login.Password = password;
                    login.UserName = username;
                    Repository<Login> repository = new Repository<Login>();
                    repository.Create(login);
                    return;
                }
                else
                {
                    Console.WriteLine("Enter all fields: Username and Password");
                    continue;
                }
            }
        }

        public bool Login()
        {
            Console.WriteLine("Enter username to login: ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password to login: ");
            string password = Console.ReadLine();
            LoginRepository repository = new LoginRepository();
            bool login = repository.GetLoginByPasswordAndUsername(username, password);
            if (login)
            {
                Console.WriteLine("Login SucessFul!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
                return false;
            }
        }
    }
}
