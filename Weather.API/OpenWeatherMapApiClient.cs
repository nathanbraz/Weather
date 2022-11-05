using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Weather.API.ViewModels;
using Weather.Domain.Entities;

namespace Weather.API
{
    public static class OpenWeatherMapApiClient
    {
        private static string BaseUrl = "https://api.openweathermap.org/data/2.5";
        private static string KeyAPI = "7051809fc0c57d78a4fbcd7d0d138983";

        public static async Task<MainViewModel> GetWeatherMapByCity(string city)
        {
            // ao fazer requisição na OpenWeatherAPI, nos devolve vários objetos, o único que precisamos é objeto main que contém as temps, por isso serializamos e desserializamos novamente e mapeamos em uma view model

            var client = new HttpClient();

            var response = await client.GetAsync($"{BaseUrl}/weather?q={city}&units=metric&appid={KeyAPI}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var jsonResult = JObject.Parse(responseBody);

            var objectMain = jsonResult["main"];

            var jsonMain = JsonConvert.SerializeObject(objectMain);

            var result = JsonConvert.DeserializeObject<MainViewModel>(jsonMain);

            return result;
        }
    }
}
