using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeFeaturesDetailsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
