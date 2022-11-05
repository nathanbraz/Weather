using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Weather.API.ViewModels;
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

        public WeatherController(IWeatherCityService serviceWeatherCity)
        {
            this.serviceWeatherCity = serviceWeatherCity;
        }

        [HttpGet]
        [Route("/api/v1/city/{city}")]
        public async Task<IActionResult> GetByCityAsync([FromRoute] string city)
        {
            try
            {
                // se retornar alguma dado significa que existem dados climáticos dos últimos 20 minutos referente a esta cidade
                var weatherCity = await serviceWeatherCity.GetByCity(city);

                // caso não retorne nada, então a requisição é feita na api externa e os dados são inseridos no bancos a serem usados como cache nos próximos 20 min
                if (weatherCity == null)
                {
                    var externalAPI = await OpenWeatherMapApiClient.GetWeatherMapByCity(city);

                    var weatherCityToCreate = new WeatherCityDTO()
                    {
                        City = city,
                        Temp = externalAPI.Temp.Value,
                        TempMin = externalAPI.TempMin.Value,
                        TempMax = externalAPI.TempMax.Value,
                        Date = DateTime.Now
                    };

                    var weatherCreated = await serviceWeatherCity.Create(weatherCityToCreate);

                    return Ok(new ResultViewModel
                    {
                        Message = "Informações recuperadas externamente.",
                        Success = true,
                        Data = weatherCreated
                    });
                }
                else
                {
                    return Ok(new ResultViewModel
                    {
                        Message = "Informações recuperadas por cache.",
                        Success = true,
                        Data = weatherCity
                    });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ResultViewModel
                {
                    Message = ex.Message,
                    Success = false,
                    Data = null
                });
            }            
        }
    }
}
