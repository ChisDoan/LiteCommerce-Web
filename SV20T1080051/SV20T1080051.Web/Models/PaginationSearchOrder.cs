using SV20T1080051.DomainModels;
using SV20T1080051.Web.Models;

namespace SV20T1080051.Web.Models
{
    public class PaginationSearchOrder : PaginationSearchBaseResult
    {
        public List<Order> Data { get; set; }
    }
}
