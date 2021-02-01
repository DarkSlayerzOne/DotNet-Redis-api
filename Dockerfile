#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 90

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Carry.Redis.Api/Carry.Redis.Api.csproj", "Carry.Redis.Api/"]
COPY ["Carry.Redis.Data/Carry.Redis.Data.csproj", "Carry.Redis.Data/"]
COPY ["Carry.Redis.Domain/Carry.Redis.Domain.csproj", "Carry.Redis.Domain/"]
COPY ["Carry.Redis.Service/Carry.Redis.Service.csproj", "Carry.Redis.Service/"]
RUN dotnet restore "Carry.Redis.Api/Carry.Redis.Api.csproj"
COPY . .
WORKDIR "/src/Carry.Redis.Api"
RUN dotnet build "Carry.Redis.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carry.Redis.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carry.Redis.Api.dll"]