FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY MeuProjetoBackend.csproj ./ 

RUN dotnet restore

COPY . ./

RUN dotnet build --configuration Release

RUN dotnet publish --configuration Release --no-build --output /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 8080

COPY --from=build /app ./

ENTRYPOINT ["dotnet", "MeuProjetoBackend.dll"]
