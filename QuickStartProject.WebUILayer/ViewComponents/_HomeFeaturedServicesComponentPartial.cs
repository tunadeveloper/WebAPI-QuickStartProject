using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeFeaturedServicesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
