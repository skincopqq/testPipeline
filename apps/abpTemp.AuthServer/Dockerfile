#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["apps/abpTemp.AuthServer/abpTemp.AuthServer.csproj", "apps/abpTemp.AuthServer/"]
COPY ["services/administration/src/abpTemp.Administration.EntityFrameworkCore/abpTemp.Administration.EntityFrameworkCore.csproj", "services/administration/src/abpTemp.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/abpTemp.Administration.Domain/abpTemp.Administration.Domain.csproj", "services/administration/src/abpTemp.Administration.Domain/"]
COPY ["services/administration/src/abpTemp.Administration.Domain.Shared/abpTemp.Administration.Domain.Shared.csproj", "services/administration/src/abpTemp.Administration.Domain.Shared/"]
COPY ["services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/abpTemp.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain/abpTemp.IdentityService.Domain.csproj", "services/identity/src/abpTemp.IdentityService.Domain/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain.Shared/abpTemp.IdentityService.Domain.Shared.csproj", "services/identity/src/abpTemp.IdentityService.Domain.Shared/"]
COPY ["services/saas/src/abpTemp.SaaS.EntityFrameworkCore/abpTemp.SaaS.EntityFrameworkCore.csproj", "services/saas/src/abpTemp.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain/abpTemp.SaaS.Domain.csproj", "services/saas/src/abpTemp.SaaS.Domain/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain.Shared/abpTemp.SaaS.Domain.Shared.csproj", "services/saas/src/abpTemp.SaaS.Domain.Shared/"]
COPY ["shared/abpTemp.Microservice.Shared/abpTemp.Microservice.Shared.csproj", "shared/abpTemp.Microservice.Shared/"]
COPY ["shared/abpTemp.Hosting.Shared/abpTemp.Hosting.Shared.csproj", "shared/abpTemp.Hosting.Shared/"]
RUN dotnet restore "./apps/abpTemp.AuthServer/./abpTemp.AuthServer.csproj"
COPY . .
WORKDIR "/src/apps/abpTemp.AuthServer"
RUN dotnet build "./abpTemp.AuthServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./abpTemp.AuthServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["apps/abpTemp.AuthServer/certificates/aspnetapp.pfx", "certificates/aspnetapp.pfx"]
ENTRYPOINT ["dotnet", "abpTemp.AuthServer.dll"]