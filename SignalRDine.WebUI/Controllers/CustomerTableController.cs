using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.MenuTableDtos;

namespace SignalRDine.WebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CustomerTableController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        public async Task<IActionResult> CustomerTableList()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("MenuTables"); // URL temizlendi
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}