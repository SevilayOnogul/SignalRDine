using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.MenuTableDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuTableController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("MenuTables");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(await responseMessage.Content.ReadAsStringAsync());
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateMenuTable() => View();

        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            createMenuTableDto.Status = false;
            var client = CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createMenuTableDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("MenuTables", content);
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.DeleteAsync($"MenuTables/{id}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMenuTable(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync($"MenuTables/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<UpdateMenuTableDto>(await responseMessage.Content.ReadAsStringAsync());
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var client = CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateMenuTableDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("MenuTables", content);
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> TableListByStatus()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("MenuTables");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(await responseMessage.Content.ReadAsStringAsync());
                return View(values);
            }
            return View();
        }
    }
}