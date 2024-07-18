# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /Tasks

# Copiar arquivos de projeto e restaurar dependências
COPY *.sln .
COPY Tasks.csproj ./Tasks/
RUN dotnet restore

# Copiar todo o código e compilar o projeto
COPY . .
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Defina a variável de ambiente para o modo de desenvolvimento
ENV ASPNETCORE_ENVIRONMENT=Development

# Expor a porta 80 para o tráfego HTTP
EXPOSE 80

# Comando de entrada para executar o aplicativo
ENTRYPOINT ["dotnet", "Tasks"]