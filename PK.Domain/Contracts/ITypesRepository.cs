using PK.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poke.Repository
{
    public interface ITypesRepository
    {
        Task<List<Move>> GetMovesFromType(string type = "fire");
    }
}