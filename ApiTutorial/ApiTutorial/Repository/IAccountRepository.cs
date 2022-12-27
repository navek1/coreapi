using ApiTutorial.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Repository
{
   public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(Signup user);
        Task<string> SignIn(SignIn signInModel);
    }
}
