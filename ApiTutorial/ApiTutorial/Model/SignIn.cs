using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiTutorial.Model
{
    public class SignIn
    {
        [Required,EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
