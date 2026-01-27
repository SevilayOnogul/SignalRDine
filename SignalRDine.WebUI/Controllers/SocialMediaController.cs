using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.SocialMediaDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SocialMediaController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("SocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSocialMedia() => View();

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("SocialMedia", stringContent);
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.DeleteAsync($"SocialMedia/{id}");
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync($"SocialMedia/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("SocialMedia", stringContent);
            if (responseMessage.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }
    }
}