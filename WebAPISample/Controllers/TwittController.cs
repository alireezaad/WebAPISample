using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Model;
using WebAPISample.Model.DBContext;
using WebAPISample.Model.ViewModel;

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
        public IActionResult GetAll()
        {
            try
            {
                return Ok(db.GetAll());
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
        [HttpPost("{viewModel}")]
        public IActionResult Post([FromBody]  TwittViewModel viewModel)
        {
            try
            {
                var twitt = db.Add(viewModel);
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
        [HttpPut("{viewModel}")]
        public IActionResult Put([FromBody] TwittViewModel viewModel)
        {
            try
            {

                var twitt = db.Update(viewModel);
                db.SaveChanges();
                return Ok(twitt);

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

        [HttpDelete("{viewModel}")]
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
