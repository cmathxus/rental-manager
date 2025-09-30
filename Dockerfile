# Imagem base
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia a solução e os projetos
COPY *.sln ./
COPY TdlImoveis.API/*.csproj TdlImoveis.API/
COPY TdlImoveis.Application/*.csproj TdlImoveis.Application/
COPY TdlImoveis.Infrastructure/*.csproj TdlImoveis.Infrastructure/
COPY TdlImoveis.Domain/*.csproj TdlImoveis.Domain/

# Restaura pacotes
RUN dotnet restore

# Copia o restante do código
COPY . .

# Build
RUN dotnet publish TdlImoveis.API/TdlImoveis.API.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "TdlImoveis.API.dll"]
