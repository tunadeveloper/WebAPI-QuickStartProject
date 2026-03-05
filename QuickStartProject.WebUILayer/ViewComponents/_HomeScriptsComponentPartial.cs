using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
