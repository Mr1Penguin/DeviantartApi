namespace DeviantartApi.Requests
{
    public class Response<T>
    {
        public Response(T result)
        {
            Result = @result;
            IsError = false;
            ErrorText = null;
        }

        public Response(bool isError, string errorText)
        {
            Result = default(T);
            IsError = isError;
            ErrorText = errorText;
        }

        public T Result { get; }

        public bool IsError { get; }

        public string ErrorText { get; }
    }
}
