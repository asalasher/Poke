using Poke.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Poke.DistributedSystems.Controllers
{
    public class MovesController : ApiController
    {
        private readonly IMovesRepository _movesRepository;

        public MovesController(IMovesRepository movesRepository)
        {
            _movesRepository = movesRepository;
        }

        // GET: api/Moves
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                List<string> names = await _movesRepository.GetMoveNames(10);
                return Ok(names);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
