#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PortFolio/API/PosTech.PortFolio.Api/PosTech.PortFolio.Api.csproj", "PortFolio/API/PosTech.PortFolio.Api/"]
COPY ["PortFolio/Controller/PosTech.PortFolio.Controllers/PosTech.PortFolio.Controllers.csproj", "PortFolio/Controller/PosTech.PortFolio.Controllers/"]
COPY ["PosTech.PortFolio.Adapter/PosTech.PortFolio.Adapter.csproj", "PosTech.PortFolio.Adapter/"]
COPY ["PortFolio/Entity/PosTech.PortFolio.Entities/PosTech.PortFolio.Entities.csproj", "PortFolio/Entity/PosTech.PortFolio.Entities/"]
COPY ["PosTech.PortFolio.Assertion/PosTech.PortFolio.Assertion.csproj", "PosTech.PortFolio.Assertion/"]
COPY ["PortFolio/Presenter/PosTech.PortFolio.Messages/PosTech.PortFolio.Messages.csproj", "PortFolio/Presenter/PosTech.PortFolio.Messages/"]
COPY ["PortFolio/Presenter/PosTech.Portfolio.Dao/PosTech.PortFolio.DAO.csproj", "PortFolio/Presenter/PosTech.Portfolio.Dao/"]
COPY ["PortFolio/Gateway/PosTech.PortFolio.Gateways/PosTech.PortFolio.Gateways.csproj", "PortFolio/Gateway/PosTech.PortFolio.Gateways/"]
COPY ["PortFolio/Interface/PosTech.PortFolio.Interfaces/PosTech.PortFolio.Interfaces.csproj", "PortFolio/Interface/PosTech.PortFolio.Interfaces/"]
COPY ["PortFolio/UseCase/PosTech.PortFolio.UseCases/PosTech.PortFolio.UseCases.csproj", "PortFolio/UseCase/PosTech.PortFolio.UseCases/"]
COPY ["Shared/PosTech.TechChallenge.Shared/PosTech.TechChallenge.Shared.csproj", "Shared/PosTech.TechChallenge.Shared/"]
COPY ["PortFolio/Infrastructure/PosTech.PorfFolio.Repository.Sql/PosTech.PortFolio.Repository.Sql.csproj", "PortFolio/Infrastructure/PosTech.PorfFolio.Repository.Sql/"]
RUN dotnet restore "./PortFolio/API/PosTech.PortFolio.Api/PosTech.PortFolio.Api.csproj"
COPY . .
WORKDIR "/src/PortFolio/API/PosTech.PortFolio.Api"
RUN dotnet build "./PosTech.PortFolio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PosTech.PortFolio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PosTech.PortFolio.Api.dll"]