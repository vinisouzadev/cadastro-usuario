namespace eSistem.Dev.Estagio.Core.Requests
{
    public class PagedRequest : Request
    {
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

    }
}
