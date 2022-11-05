using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Services.DTO;

namespace Weather.Services.Interfaces
{
    public interface IWeatherCityService
    {
        Task<WeatherCityDTO> Create(WeatherCityDTO weatherCityDTO);
        Task<WeatherCityDTO> GetByCity(string city);
    }
}
