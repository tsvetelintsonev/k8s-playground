FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["services/Nemstore.ProductsCatalog.Api/Nemstore.ProductsCatalog.Api.csproj", "services/Nemstore.ProductsCatalog.Api/"]
RUN dotnet restore "services/Nemstore.ProductsCatalog.Api/Nemstore.ProductsCatalog.Api.csproj"
COPY . .
WORKDIR "/src/services/Nemstore.ProductsCatalog.Api"
RUN dotnet build "Nemstore.ProductsCatalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nemstore.ProductsCatalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nemstore.ProductsCatalog.Api.dll"]