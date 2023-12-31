# teste-tecnico-wktechnology
Esse projeto tem a finalidade de testar o meu conhecimento técnico na criação de uma aplicação web que contenha os CRUDs de Produtos e Categorias, conforme os requisitos.

![Arquitetura](/img/arquitetura.png)

## Requisitos
A aplicação deverá ser composta por:
- Banco de dados:
  - MySQL e scripts de criação das entidades de Produtos e Categorias.
-Back-end:
  - Web API com CRUD para:
    - API de Produtos.
    - API de Categorias.
- Front-end:
  - Web Application que consuma as Webs APIs com seus respectivos CRUDs de Produtos e Categorias.
 
## Tecnologias utilizadas
[ASP.NET Core 7.0](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-7.0?view=aspnetcore-8.0) - Para a criação das Web APIs, API Gateway, e Front-end.


[Ocelot 21.0](https://github.com/ThreeMammals/Ocelot) - Para a criação de um simples API Gateway, criando um único ponto de entrada.


[MySQL 8.2.0](https://www.mysql.com/) - Como o banco de dados da solução.


[Docker](https://www.docker.com/) - Para a criação dos containers dos Microserviços.

## Executando o projeto
Para executar o projeto, basta abrir o terminal no diretório da Solution e executar o comando:

`docker compose up`

![dockercompose](/img/dockercompose-command-result.png)

O app estará executando na http://localhost:8002

![webapp](/img/webapprunning.png)

## Possíveis melhorias para próximas versões
Adicionar log e tracing, para observar o comportamento da aplicação.

Melhorar o design e experiência do usuário.

Adicionar mensageria, caso seja necessário a comunicação entre os microserviços, para a comunicação ser assincrona.

Ao hospedar na nuvem, utilizar algum serviço para substituir o Ocelot API Gateway .

Adicionar um serviço de orquestração dos containers, para garantir resiliência e alta disponibilidade.
