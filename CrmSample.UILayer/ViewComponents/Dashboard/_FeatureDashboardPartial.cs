using Microsoft.AspNetCore.Mvc;

namespace CrmSample.UILayer.ViewComponents.Dashboard
{
    public class _FeatureDashboardPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
