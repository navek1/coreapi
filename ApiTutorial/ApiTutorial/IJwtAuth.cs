using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial
{
    interface IJwtAuthManager
    {
        string authenticate(string email, string password);
    }
}
