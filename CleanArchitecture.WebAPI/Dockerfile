FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CleanArchitecture.WebAPI/CleanArchitecture.WebAPI.csproj", "CleanArchitecture.WebAPI/"]
COPY ["CleanArchitecture.Application/CleanArchitecture.Application.csproj", "CleanArchitecture.Application/"]
COPY ["CleanArchitecture.Domain/CleanArchitecture.Domain.csproj", "CleanArchitecture.Domain/"]
COPY ["CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj", "CleanArchitecture.Infrastructure/"]
COPY ["CleanArchitecture.Persistance/CleanArchitecture.Persistance.csproj", "CleanArchitecture.Persistance/"]
COPY ["CleanArchitecture.Presentation/CleanArchitecture.Presentation.csproj", "CleanArchitecture.Presentation/"]
RUN dotnet restore "./CleanArchitecture.WebAPI/./CleanArchitecture.WebAPI.csproj"
COPY . .
WORKDIR "/src/CleanArchitecture.WebAPI"
RUN dotnet build "./CleanArchitecture.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CleanArchitecture.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecture.WebAPI.dll"]