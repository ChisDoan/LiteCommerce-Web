using SV20T1080051.DomainModels;

namespace SV20T1080051.Web.Models
{
    public class PaginationSearchCategory : PaginationSearchBaseResult
    {
        public IList<Category> Data { get; set; }
    }
}
