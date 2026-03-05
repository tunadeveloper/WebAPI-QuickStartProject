using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.AboutDTOs;
using System.Text;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UpdateAbout()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(values);
                return View(jsonConvert?.LastOrDefault());
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7083/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler Güncellendi";
                return Redirect("/Admin/About/UpdateAbout");
            }
            TempData["Error"] = "Veriler Güncellenmedi";
            return Redirect("/Admin/About/UpdateAbout");
        }
    }
}
