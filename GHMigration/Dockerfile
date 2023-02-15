FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GHMigration/GHMigration.csproj", "GHMigration/"]
RUN dotnet restore "GHMigration/GHMigration.csproj"
COPY . .
WORKDIR "/src/GHMigration"
RUN dotnet build "GHMigration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GHMigration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GHMigration.dll"]
