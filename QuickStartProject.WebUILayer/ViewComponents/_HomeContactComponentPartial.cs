using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
