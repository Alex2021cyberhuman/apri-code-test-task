using System;

namespace ApriCodeTestTask.Core.Abstractions.BusinessLogic.Services.Genres.
    Models
{
    public class GenreUpdateRequest : GenreOperationRequest
    {
        public Guid Id { get; set; }
    }
}