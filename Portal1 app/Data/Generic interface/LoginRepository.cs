using Data.DbInitializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Generic_interface
{
    public class LoginRepository : IloginRepository
    {
        public bool GetLoginByPasswordAndUsername(string username, string password)
        {
           using (var portalContext = new PortalContext())
            {
                Login login = portalContext.Logins.FirstOrDefault(m => m.UserName == username && m.Password == password);
                return login != null;
            }
        
        }
    }
}
