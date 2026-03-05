using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.ContactDTOs;
using System.Text;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UpdateContact()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var jsonConvert = JsonConvert.DeserializeObject<List<ResultContactDTO>>(values);
                return View(jsonConvert?.LastOrDefault());
            }
            TempData["ErrorData"] = "Veriler Yüklenmedi";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMesage = await client.PutAsync("https://localhost:7083/api/Contact", content);
            if (responseMesage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Veriler Güncellendi";
                return Redirect("/Admin/Contact/UpdateContact");
            }
            TempData["Error"] = "Veriler Güncellenmedi";
            return Redirect("/Admin/Contact/UpdateContact");
        }
    }
}
