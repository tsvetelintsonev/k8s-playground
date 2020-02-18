FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["services/ServiceC/ServiceC.csproj", "services/ServiceC/"]
RUN dotnet restore "services/ServiceC/ServiceC.csproj"
COPY . .
WORKDIR "/src/services/ServiceC"
RUN dotnet build "ServiceC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceC.dll"]
