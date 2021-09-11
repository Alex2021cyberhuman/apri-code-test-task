using System;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.BusinessLogic.Shared.Validation;
using ApriCodeTestTask.Core.Models.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApriCodeTestTask.Api.Extensions
{
    public static class ExecutionResultExtensions
    {
        public static IActionResult GetResult<T>(
            this ExecutionResult<T> executionResult)
        {
            return executionResult.Status switch
            {
                ExecutionStatus.Success => executionResult.Result is Nothing
                    ? new NoContentResult()
                    : new OkObjectResult(executionResult.Result),
                ExecutionStatus.BadRequest => GetBadRequest(executionResult),
                ExecutionStatus.NotFound => new NotFoundResult(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static IActionResult GetBadRequest<T>(
            ExecutionResult<T> executionResult)
        {
            if (executionResult is InvalidResult<T> invalidResult)
            {
                var modelState = new ModelStateDictionary();
                if (!invalidResult.ValidationResult.IsValid)
                    foreach (var error in invalidResult.ValidationResult.Errors)
                        modelState.AddModelError(error.PropertyName,
                            error.ErrorMessage);

                return new BadRequestObjectResult(modelState);
            }

            return new BadRequestResult();
        }

        public static async Task<IActionResult> GetActionResultAsync<T>(
            this Task<ExecutionResult<T>> task)
        {
            var executionResult = await task;
            return executionResult.GetResult();
        }
    }
}