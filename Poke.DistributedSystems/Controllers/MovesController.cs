using Microsoft.Extensions.Logging;
using PK.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Poke.DistributedSystems.Controllers
{
    [RoutePrefix("api")]
    public class MovesController : ApiController
    {
        private readonly IMoveServices _movesServices;
        private readonly ILogger _logger;

        public MovesController(IMoveServices movesServices, ILogger log)
        {
            _movesServices = movesServices;
            _logger = log;
        }

        // GET: api/Moves
        [HttpGet]
        [Route("moves")]
        public async Task<IHttpActionResult> Get(string pokemonType = "fire", string language = "es", int number = 10)
        {
            //string pokemonType = Request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == "type").Value;
            //string language = Request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == "language").Value;
            //string numberOfMoves = Request.GetQueryNameValuePairs().FirstOrDefault(x => x.Key == "number").Value;

            try
            {
                //_logger.LogCritical("Critical message");
                //_logger.LogError("Error message");
                //_logger.LogWarning("Warning message");
                //_logger.LogInformation("Information message");
                //_logger.LogDebug("Debug message");
                //_logger.LogTrace("Trace message");

                //List<string> names = await _movesServices.GetTranslatedMoveNames();
                List<string> names = await _movesServices.GetTranslatedMoveNames(number, language, pokemonType);

                return Ok(names);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
