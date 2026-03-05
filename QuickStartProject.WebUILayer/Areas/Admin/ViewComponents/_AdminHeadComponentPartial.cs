using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
