using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
