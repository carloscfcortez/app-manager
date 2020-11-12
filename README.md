![API - Build and Deploy to Google Cloud](https://github.com/carloscfcortez/teste-upper/workflows/Build%20and%20Deploy%20to%20Google%20Cloud/badge.svg)
![Panel - Build and Deploy to Firebase Hosting](https://github.com/carloscfcortez/teste-upper/workflows/CI%20Panel%20-%20Frontend/badge.svg)

# Sistema de Gerenciamento de Pomar

## Escopo
Esse projeto foi desenvolvido para gerenciar Árvores, Espécies e Colheitas de um Pomar.
Conceitos e tecnologias Utilizadas foram:
- .Net Core 3.1 - c#
- Postgresql ou SQL Server
- Docker / docker-compose
- Reactjs (Reacstrap)
- DDD
- Visual Studio Code e Visual Studio 2019
- Github Action
- GCP - Cloud Run, Cloud SQL (Postgres) e Firebase hosting


## Começando

Para executar o projeto é necessário instalar o SDK do .Net Core 3.1, Visual Studio Code ou Visual Studio 2019 e Docker

- [SDK .Net Core](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [Docker](https://www.docker.com/products/docker-desktop)
- [Visual Studio Code](https://code.visualstudio.com/download)
- [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/downloads/)
- [Nodejs](https://nodejs.org/en/)
- [YARN](https://yarnpkg.com/)



## Desenvolvimento

Para contribuir com o desenvolvimento, basta fazer o clone do projeto em uma diretório de sua preferencia:

`git clone https://github.com/carloscfcortez/teste-upper.git`

## Executar
O repositório está composto por dois projetos, um Frontend ([panel](/panel)) e outro Backend ([api](/api))


## Criando o container Docker para Levantar o banco de dados Local

> Requisitos
- Ter docker instalado na máquina

O banco de dados do Postgres está na configuração apontando para o Cloud SQL do Google Cloud, para rodar o banco localhost dentro de container, basta rodar o comando de build e up do docker-compose:

Construindo a imagem do container e levantando a instancia do container no docker localmente
run command: 

`cd api`

`docker-compose build`

`docker-compose -f docker-compose.yml -d`

PS.: Caso tenha na maquina uma instanci do Postgres ou do SQL Server instalada, alterar as portas dentro do container ou apontar a conexão do `AppSettings.json` para a instancia local da maquina.


### Api
Para rodar a API, navegar pelo diretório na linha de comando ou atraves do explorer

> CLI


` cd api/AppManager.Services.Api`

Restaurar os pacotes Nuget

` dotnet restore`

Executar o Api

` dotnet run --launch-profile "AppManager.Services.Api"`

Acessar a URL de documentação do Swagger: [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

### Panel
Para rodar o panel do frontend, navegar pelo diretório pelo CLI ou abrir o projeto da pasta `panel` 

> Utilizando YARN 
- Instalando as dependencias do projeto pelo YARN
`yarn install` ou somente `yarn`

- Rodando a aplicação
`yarn start`
Abrir no navegador [http://localhost:3000](http://localhost:3000)

> Utilizando NPM
- Instalando as dependencias do projeto pelo NPM
`npm install`

- Rodando a aplicação
`npm run start`
Abrir no navegador [http://localhost:3000](http://localhost:3000)



Author: Carlos Cortez
Email: carlos.cfcortez@gmail.com
