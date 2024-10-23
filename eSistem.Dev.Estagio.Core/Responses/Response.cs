using System.Text.Json.Serialization;

namespace eSistem.Dev.Estagio.Core.Responses
{
    public class Response<TData>
    {   
        public Response(TData data, int statusCode = _code, string? message = null)
        {
            StatusCode = statusCode;

            Message = message;

            Data = data;
        }

        [JsonConstructor]
        public Response()
        {
            StatusCode = _code;
        }

        public int StatusCode { get; set; }

        public string? Message { get; set; } 

        public TData? Data { get; set; }

        public bool IsSuccess => StatusCode >= 200 && StatusCode <= 299;

        private const int _code = Configuration.DefaultStatusCode;
    }
}
