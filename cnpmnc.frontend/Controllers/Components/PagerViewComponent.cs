using cnpmnc.shared;
using Microsoft.AspNetCore.Mvc;

namespace cnpmnc.frontend.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(BaseQueryCriteria result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}