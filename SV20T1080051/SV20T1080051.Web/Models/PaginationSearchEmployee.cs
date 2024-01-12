using SV20T1080051.DomainModels;

namespace SV20T1080051.Web.Models
{
    public class PaginationSearchEmployee : PaginationSearchBaseResult
    {
        public IList<Employee> Data { get; set; }
    }
}
