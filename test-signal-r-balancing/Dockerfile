FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["test-signal-r-balancing.csproj", "."]
RUN dotnet restore "test-signal-r-balancing.csproj"
COPY . .
RUN dotnet build "test-signal-r-balancing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test-signal-r-balancing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "test-signal-r-balancing.dll", "--urls=http://0.0.0.0:3001"]