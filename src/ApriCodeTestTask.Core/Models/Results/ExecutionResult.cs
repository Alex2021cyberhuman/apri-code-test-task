namespace ApriCodeTestTask.Core.Models.Results
{
    public class ExecutionResult<T>
    {
        public ExecutionResult(T? result,
            ExecutionStatus status = ExecutionStatus.Success)
        {
            Status = status;
            Result = result;
        }

        public bool IsSuccessful => Status == ExecutionStatus.Success;

        public ExecutionStatus Status { get; set; }

        public T? Result { get; set; }

        public static ExecutionResult<T> BadRequest()
        {
            return new(default, ExecutionStatus.BadRequest);
        }

        public static ExecutionResult<T> NotFound()
        {
            return new(default, ExecutionStatus.NotFound);
        }

        public static ExecutionResult<T> Success(T result)
        {
            return new(result);
        }

        public static ExecutionResult<Nothing> SuccessEmpty()
        {
            return new(Nothing.Value);
        }
    }
}