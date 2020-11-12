![.NET Core](https://github.com/carloscfcortez/teste-upper/workflows/.NET%20Core/badge.svg?branch=main)
![CI Panel - Frontend](https://github.com/carloscfcortez/teste-upper/workflows/CI%20Panel%20-%20Frontend/badge.svg)

# Sistema de Gerenciamento de Pomar

## Escopo
Esse projeto foi desenvolvido para gerenciar Árvores, Espécies e Colheitas de um Pomar.
Conceitos e tecnologias Utilizadas foram:
- .Net Core 3.1 - c#
- SQL Server
- Docker
- Reactjs (Reacstrap)
- DDD
- Visual Studio Code e Visual Studio 2019

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
