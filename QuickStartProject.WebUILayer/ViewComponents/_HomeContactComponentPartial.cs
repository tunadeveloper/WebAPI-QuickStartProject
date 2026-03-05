using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickStartProject.WebUILayer.DTOs.ContactDTOs;
using System.Threading.Tasks;

namespace QuickStartProject.WebUILayer.ViewComponents
{
    public class _HomeContactComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7083/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ResultContactDTO>>(values);
                var model = list?.LastOrDefault();
                return View(model);
            }
            return View();
        }
    }
}
