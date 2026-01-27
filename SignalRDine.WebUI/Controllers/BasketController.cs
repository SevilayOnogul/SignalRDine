using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.BasketDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Program.cs'deki merkezi ayarı kullanan yardımcı metot
        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"] = id;
            var client = CreateClient();

            var responseMessage = await client.GetAsync($"Basket/BasketListByMenuTableWithProductName?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var menuTableId = TempData["id"];
            var client = CreateClient();

            var responseMessage = await client.DeleteAsync($"Basket/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                // Index'e giderken id'yi tekrar gönderiyoruz
                return RedirectToAction("Index", new { id = menuTableId });
            }
            return NoContent();
        }
    }
}