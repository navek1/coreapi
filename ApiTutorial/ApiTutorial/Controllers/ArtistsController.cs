using ApiTutorial.Data;
using ApiTutorial.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArtistsController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public ArtistsController(ApiDbContext _db1Context)
        {
            _dbContext = _db1Context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] artist art)
        {
            await _dbContext.Artists.AddAsync(art);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            // return Ok(_dbContext.Artists);

            var artists = await (from art in _dbContext.Artists
                                 select new
                                 {
                                     artistId = art.Id,
                                     artistName = art.name,
                                     artistGender = art.Gender

                                 }).ToListAsync();
            return Ok(artists);
        }
        //[HttpGet("[action]")]  > artistDetail?artistId=1
        [Route("artistDetail/{artistId}")]
        //artistDetail/1
        public async Task<IActionResult> artistDetail(int artistId)
        {
            var artistDetail = await (from artist in _dbContext.Artists.Where(a => a.Id == artistId).Include(a => a.Songs)
                                      select new
                                      {artistId = artist.Id,
                                      artistGender = artist.Gender,
                                      artistName = artist.name,
                                          songs =from song in artist.Songs
                                                 select new
                                                 {
                                                     Title =song.Title,
                                                     Language =song.language
                                                 }
                                      }).ToListAsync();
            return Ok(artistDetail);
        }
 
    }
}
