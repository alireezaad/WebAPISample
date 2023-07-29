using Microsoft.AspNetCore.Mvc;
using WebAPISample.Model;
using WebAPISample.Model.DBContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwittController : ControllerBase
    {
        private readonly TwittRepository db;

        public TwittController(TwittRepository twittRepository)
        {
                db = twittRepository;
        }

        // GET: api/<TwittController>
        [HttpGet]
        public async Task<IEnumerable<Twitt>> GetAll()
        {
            return await db.GetAll();
        }

        // GET api/<TwittController>/5
        [HttpGet("{id}")]
        public async Task<Twitt> Get(int id)
        {
            return await db.Get(id);
        }

        // POST api/<TwittController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Twitt twitt = new Twitt()
            {
                Body = value
            };
            db.Add(twitt);
            db.SaveChanges();
        }

        // PUT api/<TwittController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Twitt twitt = new Twitt() { 

                Id = id,
                Body = value 
            };
            db.Update(twitt);
            db.SaveChanges();
        }

        // DELETE api/<TwittController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.Delete(id);
            db.SaveChanges();
        }
    }
}
