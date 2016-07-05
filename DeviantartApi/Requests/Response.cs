namespace DeviantartApi.Requests
{
    public class Response<T>
    {
        public Response(T @object)
        {
            Object = @object;
            IsError = false;
            ErrorText = null;
        }

        public Response(bool isError, string errorText)
        {
            Object = default(T);
            IsError = isError;
            ErrorText = errorText;
        }

        public T Object { get; }
        public bool IsError { get; }
        public string ErrorText { get; }
    }
}