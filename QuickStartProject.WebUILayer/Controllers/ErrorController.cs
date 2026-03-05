using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuickStartProject.WebUILayer.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode:int}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Hoppala! Aradığınız sayfa toz olmuş.";
                    ViewBag.StatusCode = statusCode;
                    break;
                case 401:
                    ViewBag.ErrorMessage = "Hop! Buraya girmek için anahtarın yok.";
                    ViewBag.StatusCode = statusCode;
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Bir şeyler ters gitti. Galaksi biraz karışık şu an.";
                    ViewBag.StatusCode = statusCode;
                    break;
                default:
                    ViewBag.ErrorMessage = "Bir şeyler ters gitti. Galaksi biraz karışık şu an.";
                    ViewBag.StatusCode = statusCode;
                    break;
            }
            return View("HttpStatusCodeHandler");
        }
    }
}
