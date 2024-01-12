
using SV20T1080051.DomainModels;
using SV20T1080051.Web.Models;

namespace SV20T1080051.Web.Models
{
    public class PaginationSearchProduct : PaginationSearchBaseResult
    {
        public IList<Product> Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SupplierId { get; set; }
    }
}
