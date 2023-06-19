using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Poke.Repository.DataEntities;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Poke.Repository
{
    public class MovesRepository : IMovesRepository
    {
        private readonly ILogger _logger;

        private readonly HttpClient _httpClient = new HttpClient
        {
            //BaseAddress = new Uri("https://pokeapi.co/api/v2/move/")
            BaseAddress = new Uri(ConfigurationManager.AppSettings["moveUrl"])
        };

        public MovesRepository(ILogger logger)
        {
            _logger = logger;
        }

        //private readonly HttpClient _httpClient = new HttpClient();
        //HttpResponseMessage response = await _httpClient.GetAsync(_uri);
        //response.EnsureSuccessStatusCode();
        //string responseBody = await response.Content.ReadAsStringAsync();

        // Above three lines can be replaced with new helper method below
        //string responseBody = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/type/fire");

        public async Task<PK.Domain.Move> GetTranslatedMove(string id)
        {
            string languageTranslation = "es";
            try
            {
                string responseBody = await _httpClient.GetStringAsync(id);
                MoveStatsDataEntity moveStats = JsonConvert.DeserializeObject<MoveStatsDataEntity>(responseBody);

                return new PK.Domain.Move
                {
                    Id = id,
                    Name = moveStats.Names.FirstOrDefault(x => x.Language.Name == languageTranslation)?.Name, // check como funciona esto
                };
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

    }
}
