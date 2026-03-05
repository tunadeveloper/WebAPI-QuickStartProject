using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.Areas.Admin.ViewComponents
{
    public class _AdminHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
