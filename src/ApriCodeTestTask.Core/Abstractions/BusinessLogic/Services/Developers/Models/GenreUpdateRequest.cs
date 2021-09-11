using System;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Developers.
    Models
{
    public class DeveloperUpdateRequest : DeveloperOperationRequest
    {
        public Guid Id { get; set; }
    }
}