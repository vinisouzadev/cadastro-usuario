using eSistem.Dev.Estagio.Core.Responses.Errors;
using System.Text.Json.Serialization;

namespace eSistem.Dev.Estagio.Core.Responses
{
    public class Response<TData>
    {
        public Response(TData data, int statusCode = _defaultStatusCode, string? message = null)
        {
            StatusCode = statusCode;

            Message = message;

            Data = data;
        }

        [JsonConstructor]
        public Response()
        {
            StatusCode = _defaultStatusCode;
        }

        public int StatusCode { get; set; }
         
        public string? Message { get; set; } 

        public TData? Data { get; set; }

        public bool IsSuccess => StatusCode >= 200 && StatusCode <= 299;

        private const int _defaultStatusCode = Configuration.DefaultStatusCode;

        public IEnumerable<string> Errors { get; set; } = [];

    }
}
