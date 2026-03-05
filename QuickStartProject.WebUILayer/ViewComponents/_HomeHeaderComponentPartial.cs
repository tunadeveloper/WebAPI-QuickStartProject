using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
