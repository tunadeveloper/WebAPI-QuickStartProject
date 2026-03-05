using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeTestimonialsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
