using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeClientsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() => View();
    }
}
