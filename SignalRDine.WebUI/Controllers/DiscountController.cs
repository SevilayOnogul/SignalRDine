using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.DiscountDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DiscountController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("Discount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDiscount() => View();

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var client = CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Discount", stringContent);
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.DeleteAsync($"Discount/{id}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync($"Discount/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var client = CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("Discount", content);
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client = CreateClient();
            await client.GetAsync($"Discount/ChangeStatusToTrue/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = CreateClient();
            await client.GetAsync($"Discount/ChangeStatusToFalse/{id}");
            return RedirectToAction("Index");
        }
    }
}