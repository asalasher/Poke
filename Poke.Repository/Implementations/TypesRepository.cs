using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Poke.Repository.DataEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Poke.Repository
{
    public class TypesRepository : ITypesRepository
    {

        private readonly ILogger _logger;
        private readonly HttpClient _httpClient = new HttpClient
        {
            //BaseAddress = new Uri("https://pokeapi.co/api/v2/type/")
            BaseAddress = new Uri(ConfigurationManager.AppSettings["typeUrl"])
        };

        public TypesRepository(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<List<PK.Domain.Move>> GetMovesFromType(string type = "fire")
        {
            try
            {
                string responseBody = await _httpClient.GetStringAsync(type);
                TypeStatsDataEntity typeFireStats = JsonConvert.DeserializeObject<TypeStatsDataEntity>(responseBody);

                var listOfMoves = new List<PK.Domain.Move>();

                foreach (var move in typeFireStats.Moves.Take(10))
                {
                    listOfMoves.Add(new PK.Domain.Move
                    {
                        Id = move.Url.TrimEnd('/').Split('/').Last(),
                        Name = move.Name,
                    });
                }
                return listOfMoves;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}
