FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Frogobot.Core/Frogobot.Core.csproj", "Frogobot.Core/"]
RUN dotnet restore "Frogobot.Core/Frogobot.Core.csproj"
COPY . .
WORKDIR "/src/Frogobot.Core"
RUN dotnet build "./Frogobot.Core.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Frogobot.Core.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frogobot.Core.dll"]
