# Usar la imagen base de .NET 9.0 SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar dependencias
COPY ["RRHHService.API/RRHHService.API.csproj", "RRHHService.API/"]
RUN dotnet restore "RRHHService.API/RRHHService.API.csproj"

# Copiar el resto del código fuente
COPY . .
WORKDIR "/src/RRHHService.API"

# Compilar y publicar la aplicación
RUN dotnet publish "RRHHService.API.csproj" -c Release -o /app/publish

# Usar la imagen runtime más ligera para ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build /app/publish .

# Configurar variables de entorno para ASP.NET Core
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production

# Exponer el puerto
EXPOSE 5000

# Punto de entrada
ENTRYPOINT ["dotnet", "RRHHService.API.dll"]
