﻿namespace Poke.Repository.DataEntities
{
    public class TypeFireStats
    {
        public Move[] Moves { get; set; }
        public string Name { get; set; }
    }

    public class Move
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
