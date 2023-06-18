using Newtonsoft.Json;
using Poke.Repository.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Poke.Repository
{
    public class MovesRepository : IMovesRepository
    {
        //private readonly HttpClient _httpClient = new HttpClient
        //{
        //    BaseAddress = new Uri("https://pokeapi.co/api/v2/")
        //};

        private readonly HttpClient _httpClient = new HttpClient();
        private async Task<TypeFireStats> GetTypeStats()
        {

            try
            {
                //HttpResponseMessage response = await _httpClient.GetAsync(_uri);
                //response.EnsureSuccessStatusCode();
                //string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                string responseBody = await _httpClient.GetStringAsync("https://pokeapi.co/api/v2/type/fire");
                TypeFireStats typeFireStats = JsonConvert.DeserializeObject<TypeFireStats>(responseBody);
                return typeFireStats;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private async Task<MoveStats> GetMoveStats(string url)
        {

            try
            {
                string responseBody = await _httpClient.GetStringAsync(url);
                MoveStats moveStats = JsonConvert.DeserializeObject<MoveStats>(responseBody);
                return moveStats;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<string>> GetMoveNames(int number)
        {
            try
            {
                TypeFireStats typeStats = await GetTypeStats();
                List<string> listOfMovesNames = new List<string>();

                int numberOfIterations = typeStats.Moves.Count() >= number ? number : typeStats.Moves.Count();

                for (int i = 0; i < numberOfIterations; i++)
                {
                    MoveStats moveStats = await GetMoveStats(typeStats.Moves[i].Url);
                    listOfMovesNames.Add(moveStats.Names.FirstOrDefault(x => x.Language.Name == "es").Name);
                }

                //var results = await Task.WhenAll(tasks);
                //var results = await Task.WaitAll(tasks);

                return listOfMovesNames;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
