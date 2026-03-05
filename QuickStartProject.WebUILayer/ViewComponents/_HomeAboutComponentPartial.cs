using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
