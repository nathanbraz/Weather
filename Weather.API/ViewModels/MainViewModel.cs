using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Weather.API.ViewModels
{
    // Main é o objeto que contém as propriedades temp, temp_min e temp_max na api OpenWeatherMap
    public class MainViewModel
    {
        [JsonProperty(PropertyName = "temp")]
        public decimal? Temp { get; set; }

        [JsonProperty(PropertyName = "temp_min")]
        public decimal? TempMin { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public decimal? TempMax { get; set; }
    }
}
