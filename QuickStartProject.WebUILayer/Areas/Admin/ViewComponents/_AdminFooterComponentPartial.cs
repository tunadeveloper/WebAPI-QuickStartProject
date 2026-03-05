using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
