using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.TestimonialDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7263/api/Testimonial");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createTestimonialDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7263/api/Testimonial",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult>DeleteTestimonial(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7263/api/Testimonial/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult>UpdateTestimonial(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7263/api/Testimonial/{id}");
            if(responseMessage.IsSuccessStatusCode )
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateTestimonialDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMEssage = await client.PutAsync("https://localhost:7263/api/Testimonial", content);
            if(responseMEssage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> ChangeStatusTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7263/api/Testimonial/ChangeStatusTrue/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatusFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7263/api/Testimonial/ChangeStatusFalse/{id}");
            return RedirectToAction("Index");
        }
    }
}
