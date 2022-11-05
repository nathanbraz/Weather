using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Services.DTO;

namespace Weather.Tests.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WeatherCity, WeatherCityDTO>()
                    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
