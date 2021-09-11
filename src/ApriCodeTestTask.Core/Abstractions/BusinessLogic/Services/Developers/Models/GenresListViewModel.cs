using System.Collections.Generic;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models
{
    public class DevelopersListViewModel
    {
        public DevelopersListViewModel(ICollection<DeveloperViewModel> games)
        {
            Items = games;
        }

        public ICollection<DeveloperViewModel> Items { get; set; }
    }
}