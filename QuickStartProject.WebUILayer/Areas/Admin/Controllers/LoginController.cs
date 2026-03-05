using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
