using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeServicesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
