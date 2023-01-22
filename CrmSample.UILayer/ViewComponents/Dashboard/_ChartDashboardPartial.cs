using Microsoft.AspNetCore.Mvc;

namespace CrmSample.UILayer.ViewComponents.Dashboard
{
    public class _ChartDashboardPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
