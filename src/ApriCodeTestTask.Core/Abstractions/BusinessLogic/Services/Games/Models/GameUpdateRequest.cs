using System;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Games.Models
{
    public class GameUpdateRequest : GameOperationRequest
    {
        public Guid Id { get; set; }
    }
}