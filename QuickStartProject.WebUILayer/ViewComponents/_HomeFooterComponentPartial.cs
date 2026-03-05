using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
