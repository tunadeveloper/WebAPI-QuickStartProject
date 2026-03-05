using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.TestimonialDTOs;
using System.Text;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(values);
                return View(jsonConvert);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View(new List<ResultTestimonialDTO>());
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7083/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ResultTestimonialDTO>(values);
                return View(model);
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7083/api/Testimonial", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler güncellendi.";
                return Redirect("/Admin/Testimonial/Index");
            }
            TempData["Error"] = "Veriler Güncellenmedi";
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7083/api/Testimonial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler silindi.";
                return Redirect("/Admin/Testimonial/Index");
            }
            TempData["Error"] = "Veriler Silinmedi";
            return RedirectToAction("Index");
        }

        public IActionResult CreateTestimonial() => View();

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7083/api/Testimonial", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler eklendi.";
                return Redirect("/Admin/Testimonial/Index");
            }
            TempData["Error"] = "Veriler Eklenmedi";
            return View();
        }
    }
}
