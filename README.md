### Olá,

Este projeto foi feito usando .Net Core 6.0 com os pacotes nugets atualizados e usando o banco de dados MYSQL na versão 5.6, a fim de de criar uma api para consumir outra api que encontra-se neste site: https://openweathermap.org/api

O projeto está dividido em algumas camadas para mais organização, não foi levado em conta um padrão SOLID ou DDD, mas contém alguns designs pattern.

Na WeatherController está a KEY necessária para fazer requisições na api. (Lembrando que esta KEY é a do meu usuário, cada um tem a sua ao criar a conta no site).

O banco de dados foi usado localmente, então a string de conexão está relacionada ao meu banco local.