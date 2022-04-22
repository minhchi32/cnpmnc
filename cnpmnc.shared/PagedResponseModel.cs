using System.Collections.Generic;

namespace cnpmnc.shared
{
    public class PagedResponseModel<TModel> : BaseQueryCriteria
    {
        public IEnumerable<TModel> Items { get; set; }
    }
}