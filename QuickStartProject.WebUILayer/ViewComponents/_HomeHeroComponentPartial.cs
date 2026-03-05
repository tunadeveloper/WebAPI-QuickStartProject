using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeHeroComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
