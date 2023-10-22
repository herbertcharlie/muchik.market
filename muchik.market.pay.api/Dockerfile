#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["muchik.market.pay.api/muchik.market.pay.api.csproj", "muchik.market.pay.api/"]
COPY ["muchik.market.domain/muchik.market.domain.csproj", "muchik.market.domain/"]
COPY ["muchik.market.infrastructure.bus/muchik.market.infrastructure.bus.csproj", "muchik.market.infrastructure.bus/"]
COPY ["muchik.market.infrastructure.ioc/muchik.market.infrastructure.ioc.csproj", "muchik.market.infrastructure.ioc/"]
COPY ["muchik.market.pay.application/muchik.market.pay.application.csproj", "muchik.market.pay.application/"]
COPY ["muchik.market.pay.domain/muchik.market.pay.domain.csproj", "muchik.market.pay.domain/"]
COPY ["muchik.market.pay.infrastructure/muchik.market.pay.infrastructure.csproj", "muchik.market.pay.infrastructure/"]
RUN dotnet restore "muchik.market.pay.api/muchik.market.pay.api.csproj"
COPY . .
WORKDIR "/src/muchik.market.pay.api"
RUN dotnet build "muchik.market.pay.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "muchik.market.pay.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "muchik.market.pay.api.dll"]