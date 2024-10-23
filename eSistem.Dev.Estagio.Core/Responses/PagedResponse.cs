using System.Text.Json.Serialization;

namespace eSistem.Dev.Estagio.Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
            TData data,
            int statusCode,
            int totalCount,
            int currentPage = Configuration.DefaultCurrentPage,
            int pageSize = Configuration.DefaultPageSize,
            string message = null) : base(data, statusCode, message)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public PagedResponse(
            TData data,
            int statusCode = Configuration.DefaultStatusCode,
            string? message = null) : base(data, statusCode, message)
        {

        }

        public int CurrentPage { get; set; } = Configuration.DefaultCurrentPage;

        public int TotalCount { get; set; }

        public int PageSize { get; set; } = Configuration.DefaultPageSize;

    }
}
