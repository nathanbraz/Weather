### Olá,

Este projeto foi feito usando .Net Core 6.0 com os pacotes nugets atualizados e usando o banco de dados MYSQL na versão 5.6, a fim de de criar uma api para consumir outra api que encontra-se neste site: https://openweathermap.org/api

Esta API foi feita utilizando alguns padrões como SOLID. Foi usado este padrão para separar as responsabilidades, mesmo que a aplicação seja simples, está dividida em camadas para que cada camada tem a sua responsabilidade única e exclusiva.

Para executar esta API é preciso passar uma chave como parâmetro, a que está neste repositório é a chave do meu usuário cadastrado na OpenWeatherAPI. Então basta modificar a propriedade "KeyAPI" presente na classe OpenWeatherMapApiClient no projeto Weather.API

O banco de dados foi usado localmente, então a string de conexão está relacionada ao meu banco local.
O script do banco encontra-se no projeto Weather.Infra na pasta Script, depois de rodar basta mudar a string de conexão