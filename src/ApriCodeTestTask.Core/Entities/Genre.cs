using System;
using System.Collections.Generic;
using ApriCodeTestTask.Core.Abstractions.Models;

namespace ApriCodeTestTask.Core.Entities
{
    public class Genre : IEntity, IName
    {
        public Genre() : this(
            Guid.NewGuid(),
            string.Empty,
            new List<Game>())
        {
        }

        public Genre(Guid id, string name, ICollection<Game> games)
        {
            Id = id;
            Name = name;
            Games = games;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}