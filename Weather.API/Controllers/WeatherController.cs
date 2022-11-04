using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Weather.Infra.Context;

namespace Weather.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : Controller
    {
        private readonly WeatherContext context;
        private readonly string KeyAPI = "7051809fc0c57d78a4fbcd7d0d138983";

        public WeatherController(WeatherContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/api/v1/city/{city}")]
        public async Task<IActionResult> GetWeatherByCityAsync(string city)
        {
            var weatherCities = await context.WeatherCities.AsNoTracking().ToListAsync();

            return Ok(weatherCities);
        }
    }
}
