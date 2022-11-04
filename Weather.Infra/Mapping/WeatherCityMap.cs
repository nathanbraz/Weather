using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Entities;

namespace Weather.Infra.Mapping
{
    public class WeatherCityMap : IEntityTypeConfiguration<WeatherCity>
    {
        public void Configure(EntityTypeBuilder<WeatherCity> builder)
        {
            builder.ToTable("weather_city");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id")
                .HasColumnType("INT");

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("city")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Temp)
                .IsRequired()
                .HasColumnName("temp")
                .HasColumnType("DECIMAL(5,2)");

            builder.Property(x => x.TempMin)
                .IsRequired()
                .HasColumnName("temp_min")
                .HasColumnType("DECIMAL(5,2)");

            builder.Property(x => x.TempMax)
                .IsRequired()
                .HasColumnName("temp_max")
                .HasColumnType("DECIMAL(5,2)");

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("date")
                .HasColumnType("DATETIME");
        }
    }
}
