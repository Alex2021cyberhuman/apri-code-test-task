using System;
using System.Collections.Generic;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models
{
    public class GameViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid DeveloperId { get; set; }

        public GameViewModelDeveloperDto GameViewModelDeveloper { get; set; } =
            null!;

        public ICollection<GameViewModelGenreDto> Genres { get; set; } = null!;
    }
}