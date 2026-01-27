using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.NotificationDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NotificationController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("Notification");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(await responseMessage.Content.ReadAsStringAsync());
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification() => View();

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var client = CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createNotificationDto), Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Notification", content);
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            await CreateClient().DeleteAsync($"Notification/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync($"Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(await responseMessage.Content.ReadAsStringAsync());
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var client = CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(updateNotificationDto), Encoding.UTF8, "application/json");
            await client.PutAsync("Notification", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
        {
            await CreateClient().GetAsync($"Notification/NotificationStatusChangeToTrue/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
        {
            await CreateClient().GetAsync($"Notification/NotificationStatusChangeToFalse/{id}");
            return RedirectToAction("Index");
        }
    }
}