using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Infra.Context;
using Weather.Infra.Interfaces;

namespace Weather.Infra.Repositories
{
    public class WeatherCityRepository : BaseRepository<WeatherCity>, IWeatherCityRepository
    {
        private readonly WeatherContext context;
        public WeatherCityRepository(WeatherContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<WeatherCity> GetByCity(string City)
        {
            var Date = DateTime.Now.AddMinutes(-20);

            // se retornar algum dado, significa que existe um registro no banco onde a data dele é mais que vinte minutos da data atual, então se não retornar algo a aplicação deve fazer uma requisição na api externa
            var weatherCity = await context.WeatherCities
                                            .AsNoTracking()
                                            .Where(x => x.City.ToLower() == City.ToLower() && x.Date >= Date)
                                            .ToListAsync();

            return weatherCity.FirstOrDefault();

        }
    }
}
