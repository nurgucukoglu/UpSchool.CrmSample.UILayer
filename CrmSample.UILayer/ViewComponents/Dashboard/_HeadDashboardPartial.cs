using Microsoft.AspNetCore.Mvc;

namespace CrmSample.UILayer.ViewComponents.Dashboard
{
    public class _HeadDashboardPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
