using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.PricingDTOs;
using System.Text;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Pricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultPricingDTO>>(values);
                return View(jsonConvert);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View(new List<ResultPricingDTO>());
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7083/api/Pricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ResultPricingDTO>(values);
                return View(model);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7083/api/Pricing", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler güncellendi.";
                return Redirect("/Admin/Pricing/Index");
            }
            TempData["Error"] = "Veriler Güncellenmedi";
            return View();
        }

        public async Task<IActionResult> DeletePricing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7083/api/Pricing/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler silindi.";
                return Redirect("/Admin/Pricing/Index");
            }
            TempData["Error"] = "Veriler Silinmedi";
            return RedirectToAction("Index");
        }

        public IActionResult CreatePricing() => View();

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7083/api/Pricing", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler eklendi.";
                return Redirect("/Admin/Pricing/Index");
            }
            TempData["Error"] = "Veriler Eklenmedi";
            return View();
        }
    }
}
