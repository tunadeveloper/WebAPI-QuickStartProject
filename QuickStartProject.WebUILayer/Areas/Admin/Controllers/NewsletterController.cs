using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.NewsletterDTOs;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsletterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsletterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Newsletter");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultNewsletterDTO>>(values);
                return View(jsonConvert);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View(new List<ResultNewsletterDTO>());
        }

        public async Task<IActionResult> DeleteNewsletter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7083/api/Newsletter/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler silindi.";
                return Redirect("/Admin/Newsletter/Index");
            }
            TempData["Error"] = "Veriler Silinmedi";
            return RedirectToAction("Index");
        }
    }
}
