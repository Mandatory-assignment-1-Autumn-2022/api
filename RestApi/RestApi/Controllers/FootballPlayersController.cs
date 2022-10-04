using ClassLibrary;
using RestApi.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {

        private FootballPlayersManager _manager = new FootballPlayersManager();
        // GET: api/<FootballPlayersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            IEnumerable<FootballPlayer> result = _manager.GetAll();

            if (!result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

        // GET api/<FootballPlayersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer? result = _manager.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<FootballPlayersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer newPlayer)
        {
            try
            {
                FootballPlayer player = _manager.Add(newPlayer);
                return Created("api/flowers/" + player.Id, player);
            }
            catch (Exception error) 
                when(error is ArgumentNullException || error is ArgumentOutOfRangeException)
                {
                    return BadRequest(error.Message);
                }
        }
        // PUT api/<FootballPlayersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer updates)
        {
            try
            {
                FootballPlayer? result = _manager.Update(id, updates);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception error)
                when (error is ArgumentNullException || error is ArgumentOutOfRangeException)
                {
                    return BadRequest(error.Message);
                }
        }

        // DELETE api/<FootballPlayersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer? result = _manager.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
