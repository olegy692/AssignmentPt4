using Assignment1_Prog_n_tech;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentPt4.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        

        [HttpGet]
        public IEnumerable<FootballPlayer> Get()
        {
            return _manager.GetAll();
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]

        public ActionResult<FootballPlayer?> Get(int id)
        {
            FootballPlayer players = _manager.GetById(id);
            if (players == null) return NotFound("No such class, id" + id);
            return Ok(players);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public ActionResult<FootballPlayer?> Post([FromBody] FootballPlayer value)
        {
           
            try
            {
                FootballPlayer players = _manager.Add(value);

                return Created("api/FootballPlayers/" + players.Id, players);
            }
            catch (Exception ex)
            when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }

        }

        
        [HttpPut("{id}")]
        public FootballPlayer? Put(int id, [FromBody] FootballPlayer value)
        {
            return _manager.Update(id, value);
        }

        
        [HttpDelete("{id}")]
        public FootballPlayer? Delete(int id)
        {
            return _manager.Delete(id);
        }
    }


}

