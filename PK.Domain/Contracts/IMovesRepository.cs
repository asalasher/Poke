using PK.Domain;
using System.Threading.Tasks;

namespace Poke.Repository
{
    public interface IMovesRepository
    {
        Task<Move> GetTranslatedMove(string id);
    }
}
