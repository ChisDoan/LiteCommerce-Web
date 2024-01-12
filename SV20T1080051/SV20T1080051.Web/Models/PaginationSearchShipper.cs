using SV20T1080051.DomainModels;

namespace SV20T1080051.Web.Models
{
    public class PaginationSearchShipper : PaginationSearchBaseResult
    {
        public IList<Shipper> Data { get; set; }
    }
}
