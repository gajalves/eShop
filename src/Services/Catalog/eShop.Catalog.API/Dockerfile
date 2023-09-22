#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Catalog/eShop.Catalog.API/eShop.Catalog.API.csproj", "src/Services/Catalog/eShop.Catalog.API/"]
COPY ["src/Services/Catalog/eShop.Catalog.Application/eShop.Catalog.Application.csproj", "src/Services/Catalog/eShop.Catalog.Application/"]
COPY ["src/Services/Catalog/eShop.Catalog.Core/eShop.Catalog.Core.csproj", "src/Services/Catalog/eShop.Catalog.Core/"]
COPY ["src/Services/Catalog/eShop.Catalog.Infra/eShop.Catalog.Infra.csproj", "src/Services/Catalog/eShop.Catalog.Infra/"]
RUN dotnet restore "src/Services/Catalog/eShop.Catalog.API/eShop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/eShop.Catalog.API"
RUN dotnet build "eShop.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eShop.Catalog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShop.Catalog.API.dll"]