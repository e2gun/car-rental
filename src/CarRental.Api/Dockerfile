FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CarRental.Api/CarRental.Api.csproj", "src/CarRental.Api/"]
RUN dotnet restore "src/CarRental.Api/CarRental.Api.csproj"
COPY . .
WORKDIR "/src/src/CarRental.Api"
RUN dotnet build "CarRental.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRental.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRental.Api.dll"]
