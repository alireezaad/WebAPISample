using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Model.DBContext;
using WebAPISample.Model.ViewModel;
using WebAPISample.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwittController : ControllerBase
    {
        private readonly ITwittRepsitory db;

        public TwittController(ITwittRepsitory twittRepository)
        {
            db = twittRepository;
        }

        // GET: api/<TwittController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var allTwitts = db.GetAll();
                return Ok(allTwitts.ToList());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<TwittController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var twitt = db.Get(id);
                return Ok(twitt);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        // POST api/<TwittController>
        //[HttpPost("{viewModel}")]
        [HttpPost]
        public IActionResult Post([FromBody]  string body)
        {
            try
            {
                TwittViewModel twitt = new TwittViewModel() { Body = body };
                db.Add(twitt);
                db.SaveChanges();
                //return CreatedAtAction(nameof(Get),"Twitt", new { Id = twitt.Id }, twitt);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // PUT api/<TwittController>/5
        [HttpPut]
        public IActionResult Put([FromBody] TwittViewModel viewModel)
        {
            try
            {

                db.Update(viewModel);
                db.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TwittController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                db.Delete(id);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] TwittViewModel viewModel)
        {
            try
            {

                db.Delete(viewModel);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
