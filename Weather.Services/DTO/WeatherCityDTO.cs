using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Services.DTO
{
    public class WeatherCityDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public decimal Temp { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
        public DateTime Date { get; set; }
    }
}
