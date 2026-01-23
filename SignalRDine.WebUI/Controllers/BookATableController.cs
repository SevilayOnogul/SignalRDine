using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.BookingDtos;
using SignalRDine.WebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalRDine.WebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7263/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                var firstContact = values.FirstOrDefault();
                if (firstContact != null)
                {
                    ViewBag.location = firstContact.Location;

                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Index(CreateBookingDto createBookingDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7263/api/Booking", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();

            }
        }
    }
}
