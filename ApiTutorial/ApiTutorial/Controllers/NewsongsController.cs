using ApiTutorial.Data;
using ApiTutorial.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsongsController : ControllerBase
    {
        // GET: api/<NewsongsController>
        private ApiDbContext _dbContext;
        public NewsongsController(ApiDbContext apidbcontext)
        {
            _dbContext = apidbcontext;

        }
        [HttpGet]
        //public IEnumerable<song> Get()
        public IActionResult Get()
        {
            return Ok(_dbContext.Songs);
        }

        // GET api/<NewsongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record Found for this !!");
            }
            else
            {
                return Ok(song);
            }
        }

        //api/songs/[methodnamebelow]/5

        [HttpGet("[action]/{id}")]
        public int Test(int id)
        {
            return id;
        }
        // POST api/<NewsongsController>
        [HttpPost]
        [Route("createsong")]
        public async Task<IActionResult> Post([FromBody] song sng)
        {
            //_dbContext.Add(song);
            //_dbContext.SaveChanges();
            await _dbContext.Songs.AddAsync(sng);
           await  _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
            
        }

        // PUT api/<NewsongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] song sng)
        {
            var son =_dbContext.Songs.Find(id);
            son.language = sng.language;
            son.Title = sng.Title;
            _dbContext.SaveChanges();
        }

        // DELETE api/<NewsongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var son = _dbContext.Songs.Find(id);
            _dbContext.Remove(son);
            _dbContext.SaveChanges();
            return Ok("Record deleted Successfully");

        }
    }
}
