using System;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models
{
    public class GameViewModelGenreDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}