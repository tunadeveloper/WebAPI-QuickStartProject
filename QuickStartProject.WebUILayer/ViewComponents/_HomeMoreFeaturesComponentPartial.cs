using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeMoreFeaturesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
