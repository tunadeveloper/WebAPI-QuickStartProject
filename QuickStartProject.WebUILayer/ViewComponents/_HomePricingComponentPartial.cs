using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.PricingDTOs;
using System.Threading.Tasks;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomePricingComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePricingComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Pricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ResultPricingDTO>>(values);
                return View(list);
            }
            return View();
        }
    }
}
