using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.FeaturedServiceDTOs;
using System.Text;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeaturedServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/FeaturedService");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultFeaturedServiceDTO>>(values);
                return View(jsonConvert);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View(new List<ResultFeaturedServiceDTO>());
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeaturedService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7083/api/FeaturedService/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ResultFeaturedServiceDTO>(values);
                return View(model);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeaturedService(UpdateFeaturedServiceDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7083/api/FeaturedService", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler güncellendi.";
                return Redirect("/Admin/FeaturedService/Index");
            }
            TempData["Error"] = "Veriler Güncellenmedi";
            return View();
        }

        public async Task<IActionResult> DeleteFeaturedService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7083/api/FeaturedService/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler silindi.";
                return Redirect("/Admin/FeaturedService/Index");
            }
            TempData["Error"] = "Veriler Silinmedi";
            return RedirectToAction("Index");
        }

        public IActionResult CreateFeaturedService() => View();

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedService(CreateFeaturedServiceDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7083/api/FeaturedService", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler eklendi.";
                return Redirect("/Admin/FeaturedService/Index");
            }
            TempData["Error"] = "Veriler Eklenmedi";
            return View();
        }
    }
}
