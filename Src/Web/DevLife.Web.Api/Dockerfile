# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/Web/DevLife.Web.Api/DevLife.Web.Api.csproj", "Src/Web/DevLife.Web.Api/"]
COPY ["Src/Domain/DevLife.Domain/DevLife.Domain.csproj", "Src/Domain/DevLife.Domain/"]
COPY ["Src/Application/DevLife.Application/DevLife.Application.csproj", "Src/Application/DevLife.Application/"]
COPY ["Src/Shared/DevLife.Shared/DevLife.Shared.csproj", "Src/Shared/DevLife.Shared/"]
COPY ["Src/Infrastructure/DevLife.Infrastructure.Identity/DevLife.Infrastructure.Identity.csproj", "Src/Infrastructure/DevLife.Infrastructure.Identity/"]
COPY ["Src/Infrastructure/DevLife.Infrastructure/DevLife.Infrastructure.csproj", "Src/Infrastructure/DevLife.Infrastructure.Persistence/"]
RUN dotnet restore "Src/Web/DevLife.Web.Api/DevLife.Web.Api.csproj"
COPY . .
WORKDIR "/src/Src/Web/DevLife.Web.Api"
RUN dotnet build "DevLife.Web.Api.csproj" -c "$BUILD_CONFIGURATION" -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DevLife.Web.Api.csproj" -c "$BUILD_CONFIGURATION" -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevLife.Web.Api.dll"]