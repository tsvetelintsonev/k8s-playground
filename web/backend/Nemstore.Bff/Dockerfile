FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["web/backend/Nemstore.Bff/Nemstore.Bff.csproj", "web/backend/Nemstore.Bff/"]
RUN dotnet restore "web/backend/Nemstore.Bff/Nemstore.Bff.csproj"
COPY . .
WORKDIR "/src/web/backend/Nemstore.Bff/."
RUN dotnet build "Nemstore.Bff.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nemstore.Bff.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nemstore.Bff.dll"]