using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string ApiBase = "https://localhost:7083/api";

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            ViewBag.NewsletterCount = await GetCountAsync(client, $"{ApiBase}/Newsletter");
            ViewBag.MessageCount = await GetCountAsync(client, $"{ApiBase}/Message");
            ViewBag.TestimonialCount = await GetCountAsync(client, $"{ApiBase}/Testimonial");
            ViewBag.FaqCount = await GetCountAsync(client, $"{ApiBase}/Faq");
            ViewBag.ServiceCount = await GetCountAsync(client, $"{ApiBase}/Service");
            ViewBag.PricingCount = await GetCountAsync(client, $"{ApiBase}/Pricing");
            ViewBag.FeatureCount = await GetCountAsync(client, $"{ApiBase}/Feature");
            ViewBag.FeaturedServiceCount = await GetCountAsync(client, $"{ApiBase}/FeaturedService");

            return View();
        }

        private static async Task<int> GetCountAsync(HttpClient client, string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode) return 0;
                var json = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<object>>(json);
                return list?.Count ?? 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
