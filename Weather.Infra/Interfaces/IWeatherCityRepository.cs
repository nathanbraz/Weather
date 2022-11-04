using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;

namespace Weather.Infra.Interfaces
{
    public interface IWeatherCityRepository : IBaseRepository<WeatherCity>
    {
        Task<WeatherCity> GetByCity(string City);
    }
}
