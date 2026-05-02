# Multi-stage Dockerfile for .NET 10 ASP.NET Core app
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src

# Context is now the ArtifactsAPI folder, so we don't need the subfolder prefix
COPY ["ArtifactsAPI.csproj", "./"]
RUN dotnet restore "ArtifactsAPI.csproj"

# copy everything else and build
COPY . .
RUN dotnet publish -c Release -o /app/publish --no-restore

# Runtime stage (Now using the tiny Alpine image!)
FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS="http://+:80"
EXPOSE 80

ENTRYPOINT ["dotnet", "ArtifactsAPI.dll"]
