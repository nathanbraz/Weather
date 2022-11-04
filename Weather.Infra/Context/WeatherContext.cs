using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;
using Weather.Infra.Mapping;

namespace Weather.Infra.Context
{
    public class WeatherContext : DbContext 
    {
        public WeatherContext() {}

        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

        public virtual DbSet<WeatherCity> WeatherCities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WeatherCityMap());
        }
    }
}
