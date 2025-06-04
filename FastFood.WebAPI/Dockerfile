# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ./FastFood.sln .
COPY ./FastFood.Domain ./FastFood.Domain
COPY ./FastFood.Application ./FastFood.Application
COPY ./FastFood.Infrastructure ./FastFood.Infrastructure
COPY ./FastFood.WebAPI ./FastFood.WebAPI

RUN dotnet restore ./FastFood.WebAPI/FastFood.WebAPI.csproj
RUN dotnet publish ./FastFood.WebAPI/FastFood.WebAPI.csproj -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FastFood.WebAPI.dll"]
