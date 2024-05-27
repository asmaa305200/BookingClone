FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/BookingClone.API/BookingClone.API.csproj", "src/Services/BookingClone.API/"]
COPY ["src/Common/BookingClone.Serilog/BookingClone.Serilog.csproj", "src/Common/BookingClone.Serilog/"]
COPY ["src/Services/BookingClone.Application/BookingClone.Application.csproj", "src/Services/BookingClone.Application/"]
COPY ["src/Services/BookingClone.Infrastructure/BookingClone.Infrastructure.csproj", "src/Services/BookingClone.Infrastructure/"]
COPY ["src/Services/BookingClone.Domain/BookingClone.Domain.csproj", "src/Services/BookingClone.Domain/"]
RUN dotnet restore "src/Services/BookingClone.API/BookingClone.API.csproj"
COPY . .
WORKDIR "/src/src/Services/BookingClone.API"
RUN dotnet build "BookingClone.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingClone.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingClone.API.dll"]