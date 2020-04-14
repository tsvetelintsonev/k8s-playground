#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["web/backend/Nemstore.Orders.Bff/Nemstore.Orders.Bff.csproj", "web/backend/Nemstore.Orders.Bff/"]
RUN dotnet restore "web/backend/Nemstore.Orders.Bff/Nemstore.Orders.Bff.csproj"
COPY . .
WORKDIR "/src/web/backend/Nemstore.Orders.Bff"
RUN dotnet build "Nemstore.Orders.Bff.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nemstore.Orders.Bff.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nemstore.Orders.Bff.dll"]