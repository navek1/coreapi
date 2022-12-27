using ApiTutorial.Data;
using ApiTutorial.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private ApiDbContext _dbcontext;
        public AlbumsController(ApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] album alb)
        {
            await _dbcontext.Albums.AddAsync(alb);
            await _dbcontext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
