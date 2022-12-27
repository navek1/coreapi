using ApiTutorial.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Data
{
    public class ApiDbContext:IdentityDbContext<User>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options):base(options)
        {

        }
        public DbSet<song> Songs { get; set; }
        public DbSet<artist> Artists { get; set; }
        public DbSet<album> Albums { get; set; }

    }
}
