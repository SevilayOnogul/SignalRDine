using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.BookingDtos;
using SignalRDine.WebUI.Dtos.ContactDtos;
using SignalRDine.WebUI.Models;
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

        // Merkezi URL yapısını kullanan yardımcı metot
        private HttpClient CreateClient() => _httpClientFactory.CreateClient("SignalRClient");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("Contact");

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
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var client = CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("Booking", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            var errorResponse = await responseMessage.Content.ReadFromJsonAsync<ApiValidationErrorResponse>();
            if (errorResponse?.Errors != null)
            {
                foreach (var error in errorResponse.Errors)
                {
                    foreach (var errorMessage in error.Value)
                    {
                        ModelState.AddModelError(error.Key, errorMessage);
                    }
                }
            }

            return View();
        }
    }
}