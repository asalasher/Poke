using Microsoft.Extensions.Logging;
using Poke.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PK.Domain.Services
{
    public class MoveServices : IMoveServices
    {
        private readonly ILogger _logger;
        private readonly IMovesRepository _movesRepository;
        private readonly ITypesRepository _typesRepository;

        public MoveServices(ILogger logger, IMovesRepository movesRepository, ITypesRepository typesRepository)
        {
            _logger = logger;
            _movesRepository = movesRepository;
            _typesRepository = typesRepository;
        }

        public async Task<List<string>> GetSpanishMoveNames()
        {
            List<Move> typeMovesWithEnglishNames = await _typesRepository.GetMovesFromType();
            List<string> listOfMovesNames = new List<string>();

            foreach (var move in typeMovesWithEnglishNames)
            {
                Move translatedMove = await _movesRepository.GetTranslatedMove(move.Id);
                listOfMovesNames.Add(translatedMove.Name);
            }
            return listOfMovesNames;
        }

    }
}
