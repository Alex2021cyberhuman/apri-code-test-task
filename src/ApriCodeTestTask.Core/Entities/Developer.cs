using System;
using System.Collections.Generic;
using ApriCodeTestTask.Core.Abstractions.Models;

namespace ApriCodeTestTask.Core.Entities
{
    public class Developer : IEntity, IName
    {
        public Developer() : this(Guid.NewGuid(), string.Empty,
            new List<Game>())
        {
        }

        public Developer(Guid id, string name, ICollection<Game> games)
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