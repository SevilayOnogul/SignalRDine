using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.TestimonialDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TestimonialController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var response = await client.GetAsync("Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(await response.Content.ReadAsStringAsync());
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial() => View();

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client = CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(createTestimonialDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Testimonial", content);
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var response = await CreateClient().DeleteAsync($"Testimonial/{id}");
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var response = await CreateClient().GetAsync($"Testimonial/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(await response.Content.ReadAsStringAsync());
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(updateTestimonialDto), Encoding.UTF8, "application/json");
            var response = await CreateClient().PutAsync("Testimonial", content);
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> ChangeStatusTrue(int id)
        {
            await CreateClient().GetAsync($"Testimonial/ChangeStatusTrue/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatusFalse(int id)
        {
            await CreateClient().GetAsync($"Testimonial/ChangeStatusFalse/{id}");
            return RedirectToAction("Index");
        }
    }
}