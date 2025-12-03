namespace Domain.Definitions.Results
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public Response() { }

        public Response(int statusCode, string message, T? data = default)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public static Response<T> Create(int statusCode, string message, T? data = default)
            => new Response<T>(statusCode, message, data);
    }
}
