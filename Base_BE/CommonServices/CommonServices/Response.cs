using System.Text.Json.Serialization;

namespace CommonServices
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Response(int status, string? message = null)
        {
            Status = status;
            Message = message ?? string.Empty;
        }
    }

    public class Response<T> : Response
    {
        public T? Data { get; set; }

        [JsonConstructor]
        public Response(
            int status, string? message = null, T? data = default)
            : base(status, message)
        {
            Data = data;
        }
    }

    public class ResponseTable<T> : Response<T>
    {
        public int TotalRecords { get; set; }
        public ResponseTable(
            int status, string? message = null, T? data = default, int totalRecords = 0)
            : base(status, message, data)
        {
            TotalRecords = totalRecords;
        }
    }
}
