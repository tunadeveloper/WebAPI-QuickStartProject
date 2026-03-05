using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.ServiceDTOs;
using System.Text;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(values);
                return View(jsonConvert);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View(new List<ResultServiceDTO>());
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7083/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ResultServiceDTO>(values);
                return View(model);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7083/api/Service", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler güncellendi.";
                return Redirect("/Admin/Service/Index");
            }
            TempData["Error"] = "Veriler Güncellenmedi";
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7083/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler silindi.";
                return Redirect("/Admin/Service/Index");
            }
            TempData["Error"] = "Veriler Silinmedi";
            return RedirectToAction("Index");
        }

        public IActionResult CreateService() => View();

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7083/api/Service", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler eklendi.";
                return Redirect("/Admin/Service/Index");
            }
            TempData["Error"] = "Veriler Eklenmedi";
            return View();
        }
    }
}
