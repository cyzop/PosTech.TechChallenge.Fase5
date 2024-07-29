#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PosTech.PortFolioWeb/Server/PosTech.PortFolioWeb.Server.csproj", "PosTech.PortFolioWeb/Server/"]
COPY ["PosTech.PortFolioWeb/Client/PosTech.PortFolioWeb.Client.csproj", "PosTech.PortFolioWeb/Client/"]
COPY ["PosTech.PortFolioWeb/Shared/PosTech.PortFolioWeb.Shared.csproj", "PosTech.PortFolioWeb/Shared/"]
RUN dotnet restore "./PosTech.PortFolioWeb/Server/PosTech.PortFolioWeb.Server.csproj"
COPY . .
WORKDIR "/src/PosTech.PortFolioWeb/Server"
RUN dotnet build "./PosTech.PortFolioWeb.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PosTech.PortFolioWeb.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PosTech.PortFolioWeb.Server.dll"]