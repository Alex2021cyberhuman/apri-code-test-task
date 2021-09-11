using System;
using System.Collections.Generic;
using ApriCodeTestTask.Core.Abstractions.Models;

namespace ApriCodeTestTask.Core.Entities
{
    public class Game : IEntity, IName
    {
        public Game() : this(
            Guid.NewGuid(),
            string.Empty,
            null,
            Guid.Empty,
            null!)
        {
        }

        public Game(Guid id, string name, ICollection<Genre>? genres,
            Guid developerId, Developer developer)
        {
            Id = id;
            Name = name;
            DeveloperId = developerId;
            Developer = developer;
            Genres = genres ?? new List<Genre>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public Guid DeveloperId { get; set; }

        public Developer Developer { get; set; } = null!;
    }
}