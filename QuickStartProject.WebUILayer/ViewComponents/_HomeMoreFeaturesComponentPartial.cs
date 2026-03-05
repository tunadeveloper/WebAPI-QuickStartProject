using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.FeatureDTOs;
using System.Threading.Tasks;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeMoreFeaturesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeMoreFeaturesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Feature");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(values);
                return View(list);
            }
            return View();
        }
    }
}
