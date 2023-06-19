using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public MovesController(IMovesRepository movesRepository, ILogger log)
        {
            _movesRepository = movesRepository;
            _logger = log;
        }

        // GET: api/Moves
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                _logger.LogCritical("Critical message");
                _logger.LogError("Error message");
                _logger.LogWarning("Warning message");
                _logger.LogInformation("Information message");
                _logger.LogDebug("Debug message");
                _logger.LogTrace("Trace message");

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
