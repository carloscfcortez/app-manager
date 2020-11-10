![.NET Core](https://github.com/carloscfcortez/teste-upper/workflows/.NET%20Core/badge.svg?branch=main)

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

## Desenvolvimento

Para contribuir com o desenvolvimento, basta fazer o clone do projeto em uma diretório de sua preferencia:

`git clone https://github.com/carloscfcortez/teste-upper.git`

## Executar
O repositório está composto por dois projetos, um Frontend ([panel](/panel)) e outro Backend ([api](/panel))

### Api
Para rodar a API, navegar pelo diretório na linha de comando ou atraves do explorer

> CLI


` cd api/AppManager.Services.Api`

Restaurar os pacotes Nuget

` dotnet restore`

Executar o Api

` dotnet run`