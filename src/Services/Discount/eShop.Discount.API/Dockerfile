#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Discount/eShop.Discount.API/eShop.Discount.API.csproj", "src/Services/Discount/eShop.Discount.API/"]
COPY ["src/Services/Discount/eShop.Discount.Application/eShop.Discount.Application.csproj", "src/Services/Discount/eShop.Discount.Application/"]
COPY ["src/Services/Discount/eShop.Discount.Core/eShop.Discount.Core.csproj", "src/Services/Discount/eShop.Discount.Core/"]
COPY ["src/Services/Discount/eShop.Discount.Infra/eShop.Discount.Infra.csproj", "src/Services/Discount/eShop.Discount.Infra/"]
RUN dotnet restore "src/Services/Discount/eShop.Discount.API/eShop.Discount.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Discount/eShop.Discount.API"
RUN dotnet build "eShop.Discount.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eShop.Discount.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShop.Discount.API.dll"]