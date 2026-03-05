using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.NewsletterDTOs;
using System.Text;
using System.Threading.Tasks;

namespace QuickStartProject.WebUILayer.Controllers
{
    [AllowAnonymous]
    public class NewsletterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsletterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Subscribe(CreateNewsletterDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonConvert = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonConvert, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7083/api/Newsletter", content);
            return Redirect("/Home/Index");
        }
    }
}
