using System.Collections.Generic;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.
    Models
{
    public class GenresListViewModel
    {
        public GenresListViewModel(ICollection<GenreViewModel> games)
        {
            Items = games;
        }

        public ICollection<GenreViewModel> Items { get; set; }
    }
}