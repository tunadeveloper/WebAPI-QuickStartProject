using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.Areas.Admin.Models;
using QuickStartProject.WebUILayer.DTOs.MessageDTOs;
using QuickStartProject.WebUILayer.DTOs.NewsletterDTOs;

namespace QuickStartProject.WebUILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var messageRes = await client.GetAsync("https://localhost:7083/api/Message");
            var messagesList = new List<ResultMessageDTO>();
            if (messageRes.IsSuccessStatusCode)
            {
                var jsonMsg = await messageRes.Content.ReadAsStringAsync();
                messagesList = JsonConvert.DeserializeObject<List<ResultMessageDTO>>(jsonMsg);
            }
            ViewBag.MessageCount = messagesList.Count;

            var newsletterRes = await client.GetAsync("https://localhost:7083/api/Newsletter");
            var newsletterList = new List<ResultNewsletterDTO>();
            if (newsletterRes.IsSuccessStatusCode)
            {
                var jsonNews = await newsletterRes.Content.ReadAsStringAsync();
                newsletterList = JsonConvert.DeserializeObject<List<ResultNewsletterDTO>>(jsonNews);
            }
            ViewBag.NewsletterCount = newsletterList.Count;

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-news-data.p.rapidapi.com/search?query=Business&limit=10&time_published=anytime&country=TR&lang=tr"),
                Headers =
                {
                    { "x-rapidapi-key", "cdb47aa04cmsh29c897da07c93f7p193945jsn7a061eae88f6" },
                    { "x-rapidapi-host", "real-time-news-data.p.rapidapi.com" }
                }
            };

            var rapidNews = new List<Datum>();
            using var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var news = JsonConvert.DeserializeObject<News>(body);
                rapidNews = news.data.OrderByDescending(x => x.published_datetime_utc).Take(6).ToList();
            }
            ViewBag.RapidApiLast6 = rapidNews;

            return View();
        }
    }
}
