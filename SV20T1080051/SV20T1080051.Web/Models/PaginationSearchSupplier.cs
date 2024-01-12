using SV20T1080051.DomainModels;

namespace SV20T1080051.Web.Models
{
    public class PaginationSearchSupplier : PaginationSearchBaseResult
    {
        public IList<Supplier> Data { get; set; }
    }
}
