using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminNavComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
