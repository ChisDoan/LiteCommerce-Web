using SV20T1080051.DomainModels;
using SV20T1080051.Web.Models;

namespace SV20T1080051.Web.Models
{
    public class PaginationSearchCustomer : PaginationSearchBaseResult
    {
        public IList<Customer> Data { get; set; }
    }
}
