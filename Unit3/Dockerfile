FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Unit3/Unit3.csproj", "Unit3/"]
RUN dotnet restore "Unit3/Unit3.csproj"
COPY . .
WORKDIR "/src/Unit3"
RUN dotnet build "Unit3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unit3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unit3.dll"]
