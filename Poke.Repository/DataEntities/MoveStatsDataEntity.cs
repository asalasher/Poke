namespace Poke.Repository.DataEntities
{
    public class MoveStatsDataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MoveName[] Names { get; set; }
    }

    public class MoveName
    {
        public Language Language { get; set; }
        public string Name { get; set; }
    }

    public class Language
    {
        public string Name { get; set; }
    }
}
