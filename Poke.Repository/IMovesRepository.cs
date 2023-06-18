namespace Poke.Repository
{
    public interface IMovesRepository
    {
        System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetMoveNames(int number);
    }
}