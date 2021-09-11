using System;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.
    Models
{
    public class GenreViewModel
    {
        public GenreViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}