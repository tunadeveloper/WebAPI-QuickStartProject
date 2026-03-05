using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeFeaturesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
