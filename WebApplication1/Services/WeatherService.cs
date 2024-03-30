namespace WebApplication1.Services
{
    // Services/WeatherService.cs
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherDataAsync(string city, string apiKey)
        {
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
            return weatherData;
        }
    }

    public class WeatherData
    {
        public MainInfo Main { get; set; }
        public string Name { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
    }

}
