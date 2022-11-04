using AutoMapper;
using Weather.Domain.Entities;
using Weather.Services.DTO;

namespace Weather.API.AutoMapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<WeatherCity, WeatherCityDTO>();
            CreateMap<WeatherCityDTO, WeatherCity>();
        }
    }
}
