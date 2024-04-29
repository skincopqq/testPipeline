#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["shared/abpTemp.DbMigrator/abpTemp.DbMigrator.csproj", "shared/abpTemp.DbMigrator/"]
COPY ["services/administration/src/abpTemp.Administration.Application.Contracts/abpTemp.Administration.Application.Contracts.csproj", "services/administration/src/abpTemp.Administration.Application.Contracts/"]
COPY ["services/administration/src/abpTemp.Administration.Domain.Shared/abpTemp.Administration.Domain.Shared.csproj", "services/administration/src/abpTemp.Administration.Domain.Shared/"]
COPY ["services/administration/src/abpTemp.Administration.EntityFrameworkCore/abpTemp.Administration.EntityFrameworkCore.csproj", "services/administration/src/abpTemp.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/abpTemp.Administration.Domain/abpTemp.Administration.Domain.csproj", "services/administration/src/abpTemp.Administration.Domain/"]
COPY ["services/identity/src/abpTemp.IdentityService.Application.Contracts/abpTemp.IdentityService.Application.Contracts.csproj", "services/identity/src/abpTemp.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain.Shared/abpTemp.IdentityService.Domain.Shared.csproj", "services/identity/src/abpTemp.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/abpTemp.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain/abpTemp.IdentityService.Domain.csproj", "services/identity/src/abpTemp.IdentityService.Domain/"]
COPY ["services/saas/src/abpTemp.SaaS.Application.Contracts/abpTemp.SaaS.Application.Contracts.csproj", "services/saas/src/abpTemp.SaaS.Application.Contracts/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain.Shared/abpTemp.SaaS.Domain.Shared.csproj", "services/saas/src/abpTemp.SaaS.Domain.Shared/"]
COPY ["services/saas/src/abpTemp.SaaS.EntityFrameworkCore/abpTemp.SaaS.EntityFrameworkCore.csproj", "services/saas/src/abpTemp.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain/abpTemp.SaaS.Domain.csproj", "services/saas/src/abpTemp.SaaS.Domain/"]
COPY ["shared/abpTemp.Microservice.Shared/abpTemp.Microservice.Shared.csproj", "shared/abpTemp.Microservice.Shared/"]
COPY ["shared/abpTemp.Hosting.Shared/abpTemp.Hosting.Shared.csproj", "shared/abpTemp.Hosting.Shared/"]
RUN dotnet restore "shared/abpTemp.DbMigrator/abpTemp.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/abpTemp.DbMigrator"
RUN dotnet build "abpTemp.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "abpTemp.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "abpTemp.DbMigrator.dll"]