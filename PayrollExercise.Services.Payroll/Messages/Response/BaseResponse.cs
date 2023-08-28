namespace PayrollExercise.Services.Messages.Response
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }

        public string Message { get; set; } = string.Empty;

        public int StatusCode { get; set; }
    }
}
