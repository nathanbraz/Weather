using AutoMapper;
using FluentAssertions;
using Moq;
using Weather.Domain.Entities;
using Weather.Infra.Interfaces;
using Weather.Infra.Repositories;
using Weather.Services.DTO;
using Weather.Services.Interfaces;
using Weather.Services.Services;
using Weather.Tests.Configuration;
using Xunit;

namespace Weather.Tests.Projects.Services
{
    public class WeatherCityServiceTests
    {
        private readonly IWeatherCityService sut;
        private readonly IMapper mapper;
        private readonly Mock<IWeatherCityRepository> weatherCityRepositoryMock;

        public WeatherCityServiceTests()
        {
            this.mapper = AutoMapperConfiguration.GetConfiguration();
            weatherCityRepositoryMock = new Mock<IWeatherCityRepository>();

            this.sut = new WeatherCityService
            (
                weatherCityRepository: this.weatherCityRepositoryMock.Object,
                mapper: this.mapper                
            );
        }

        //Criação do usuário quando a última requisição for feita há mais de 20 minutos e for requisitado na api externa
        [Fact(DisplayName = "Create Weather City")]
        [Trait("Category", "Services")]
        public async Task Create_WhenHaveResponsOnAPI_ReturnsWeatherCityDTO()
        {
            // Arrange
            var weatherCityToCreate = new WeatherCityDTO()
            {
                Id = 1,
                City = "Brasilia",
                Date = DateTime.Now,
                Temp = (decimal)22.15,
                TempMin = (decimal)22.15,
                TempMax = (decimal)22.15
            };
            var weatherCityCreated = mapper.Map<WeatherCity>(weatherCityToCreate);

            weatherCityRepositoryMock.Setup(x => x.Create(It.IsAny<WeatherCity>()))
                .ReturnsAsync(() => weatherCityCreated);

            // Act
            var result = await sut.Create(weatherCityToCreate);

            //Assert
            result.Should()
                .BeEquivalentTo(mapper.Map<WeatherCityDTO>(weatherCityCreated));
        }
    }
}
