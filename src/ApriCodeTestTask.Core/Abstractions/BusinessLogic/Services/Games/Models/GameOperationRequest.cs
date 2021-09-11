using System;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models
{
    public abstract class GameOperationRequest
    {
        public string Name { get; set; } = string.Empty;

        public Guid DeveloperId { get; set; }
    }
}