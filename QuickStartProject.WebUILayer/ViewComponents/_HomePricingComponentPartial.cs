using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomePricingComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
