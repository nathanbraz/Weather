using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Weather.Infra.Context;
using Weather.Services.DTO;
using Weather.Services.Interfaces;

namespace Weather.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherCityService serviceWeatherCity;

        private readonly string KeyAPI = "7051809fc0c57d78a4fbcd7d0d138983";

        public WeatherController(IWeatherCityService serviceWeatherCity)
        {
            this.serviceWeatherCity = serviceWeatherCity;
        }

        [HttpGet]
        [Route("/api/v1/city/{City}")]
        public async Task<IActionResult> GetByCityAsync([FromRoute] string City)
        {
            // se retornar alguma dado significa que existem dados climáticos dos últimos 20 minutos referente a esta cidade
            var weatherCities = await serviceWeatherCity.GetByCity(City);

            if(weatherCities == null)
            {
                var teste = await GetWeatherMapByCity(City);

                var weather2 = new WeatherCityDTO()
                {
                    City = City,
                    Temp = teste.Temp.Value,
                    TempMin = teste.TempMin.Value,
                    TempMax = teste.TempMax.Value,
                    Date = DateTime.Now
                };

                var weatherCreated = await serviceWeatherCity.Create(weather2);

                return Ok(weatherCreated);
            }
            else
            {
                return Ok(weatherCities);
            }            
        }

        [NonAction]
        public async Task<Main> GetWeatherMapByCity(string City)
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={City}&units=metric&appid={this.KeyAPI}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var jsonResult = JObject.Parse(responseBody);

            var main = jsonResult["main"];

            var newJson = JsonConvert.SerializeObject(main);

            var result = JsonConvert.DeserializeObject<Main>(newJson);

            return result;
        }
    }

    
    public class Main
    {
        [JsonProperty(PropertyName = "temp")]
        public decimal? Temp { get; set; }

        [JsonProperty(PropertyName = "feels_like")]
        public decimal? FeelsLike { get; set; }

        [JsonProperty(PropertyName = "temp_min")]
        public decimal? TempMin { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public decimal? TempMax { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public decimal? Pressure { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public decimal? Humidity { get; set; }

        [JsonProperty(PropertyName = "sea_level")]
        public int? SeaLevel { get; set; }

        [JsonProperty(PropertyName = "grnd_level")]
        public int? GrndLevel { get; set; }
    }
}
