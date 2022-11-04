using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Infra.Interfaces;
using Weather.Services.DTO;
using Weather.Services.Interfaces;

namespace Weather.Services.Services
{
    public class WeatherCityService : IWeatherCityService
    {
        private readonly IWeatherCityRepository weatherCityRepository;
        private readonly IMapper mapper;
        public WeatherCityService(IWeatherCityRepository weatherCityRepository, IMapper mapper)
        {
            this.weatherCityRepository = weatherCityRepository;
            this.mapper = mapper;
        }

        public async Task<WeatherCityDTO> Create(WeatherCityDTO weatherCityDTO)
        {
            var weatherCity = mapper.Map<WeatherCity>(weatherCityDTO);

            var created = await weatherCityRepository.Create(weatherCity);

            return mapper.Map<WeatherCityDTO>(created);
        }

        public async Task<WeatherCityDTO> GetByCity(string City)
        {
            var weatherCity = await weatherCityRepository.GetByCity(City);

            return mapper.Map<WeatherCityDTO>(weatherCity);
        }

        //public Task<WeatherCityDTO> Update(WeatherCityDTO userDTO)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
