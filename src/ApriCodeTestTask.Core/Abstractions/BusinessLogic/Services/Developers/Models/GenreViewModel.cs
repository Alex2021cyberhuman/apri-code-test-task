using System;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models
{
    public class DeveloperViewModel
    {
        public DeveloperViewModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}