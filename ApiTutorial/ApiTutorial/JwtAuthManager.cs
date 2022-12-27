using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial
{
    public class JwtAuthManager : IJwtAuthManager
    {

        public readonly IDictionary<string, string> users = new Dictionary<string, string>{
            {"test1","pass1" }
            };
        public string authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
