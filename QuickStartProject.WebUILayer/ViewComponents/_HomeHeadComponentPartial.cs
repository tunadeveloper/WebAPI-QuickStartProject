using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
