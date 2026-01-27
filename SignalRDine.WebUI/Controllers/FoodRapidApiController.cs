using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDine.WebUI.Dtos.RapidApiDtos;

public class FoodRapidApiController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public FoodRapidApiController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=60&tags=under_30_minutes"),
            Headers =
            {
                { "x-rapidapi-key", "a549d544b1msh67e211c6ab180fdp1a3f5djsnc5817f75056b" },
                { "x-rapidapi-host", "tasty.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
            return View(root.Results.ToList());
        }
    }
}