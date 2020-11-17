#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80/tcp
EXPOSE 443/tcp

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /
COPY ["src/AppManager.Services.Api/AppManager.Services.Api.csproj", "src/AppManager.Services.Api/"]
COPY ["src/AppManager.Infrastructure.CrossCutting/AppManager.Infrastructure.CrossCutting.csproj", "src/AppManager.Infrastructure.CrossCutting/"]
COPY ["src/AppManager.Domain/AppManager.Domain.csproj", "src/AppManager.Domain/"]
COPY ["src/AppManager.Infrastructure.Data/AppManager.Infrastructure.Data.csproj", "src/AppManager.Infrastructure.Data/"]
COPY ["src/AppManager.Application/AppManager.Application.csproj", "src/AppManager.Application/"]
RUN dotnet restore "src/AppManager.Services.Api/AppManager.Services.Api.csproj"
COPY . .

WORKDIR "/src/AppManager.Services.Api"
RUN dotnet build "AppManager.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppManager.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppManager.Services.Api.dll"]