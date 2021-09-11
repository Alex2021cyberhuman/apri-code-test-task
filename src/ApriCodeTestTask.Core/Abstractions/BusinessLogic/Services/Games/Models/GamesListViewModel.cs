using System.Collections.Generic;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models
{
    public class GamesListViewModel
    {
        public GamesListViewModel(ICollection<GameViewModel> items)
        {
            Items = items;
        }

        public ICollection<GameViewModel> Items { get; set; }
    }
}