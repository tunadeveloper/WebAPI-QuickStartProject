using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeFaqComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
