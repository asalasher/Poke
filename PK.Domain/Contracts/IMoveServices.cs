using System.Collections.Generic;
using System.Threading.Tasks;

namespace PK.Domain.Services
{
    public interface IMoveServices
    {
        Task<List<string>> GetSpanishMoveNames();
    }
}