using cnpmnc.shared.Enums;

namespace cnpmnc.shared
{
    public class BaseQueryCriteria
    {
        public string Search { get; set; }
        public int Limit { get; set; } = 5;
        public int Page { get; set; } = 1;
        public SortOrderEnumDto SortOrder { get; set; }
        public string SortColumn { get; set; } = "ID";
        public int TotalRecord { get; set; }
        public int PageCount
        {
            get
            {
                var pageCount = TotalRecord * 1.0 / Limit;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}