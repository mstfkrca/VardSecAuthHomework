FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src



# Proje dosyalarını kopyala
COPY ["VardSecAuth.API/VardSecAuth.API.csproj", "VardSecAuth.API/"]
COPY ["VardSecAuth.Core/VardSecAuth.Core.csproj", "VardSecAuth.Core/"]
COPY ["VardSecAuth.Data/VardSecAuth.Data.csproj", "VardSecAuth.Data/"]
COPY ["VardSecAuth.Service/VardSecAuth.Service.csproj", "VardSecAuth.Service/"]




# Tüm kaynak kodları kopyala (Migration dosyaları dahil)
COPY . .

#Restore
RUN dotnet restore VardSecAuth.API/VardSecAuth.API.csproj
# Build


# Publish
WORKDIR /src/VardSecAuth.API
RUN dotnet publish VardSecAuth.API.csproj -c Release -o /app/publish /p:UseAppHost=false


# Final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "VardSecAuth.API.dll"]