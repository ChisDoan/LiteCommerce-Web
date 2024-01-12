namespace SV20T1080051.Web.Models
{
    public class PaginationSearchInput
    {
        public int Page { get; set; } =1;

        public int PageSize { get; set; } = 20;

        public string SearchValue { get; set; } = "";

        public int categoryID { get; set; } = 0;

        public int supplierID { get; set; }=0;

        public decimal minPrice { get; set; } = 0;

        public decimal maxPrice { get; set; } = 0;
    }
}
