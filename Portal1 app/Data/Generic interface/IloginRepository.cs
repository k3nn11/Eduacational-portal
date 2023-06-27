using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Generic_interface
{
    public  interface IloginRepository
    {
        bool GetLoginByPasswordAndUsername(string username, string password);
        
    }
}
