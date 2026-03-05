using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebUILayer.Models;
using System.Diagnostics;

namespace QuickStartProject.WebUILayer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
