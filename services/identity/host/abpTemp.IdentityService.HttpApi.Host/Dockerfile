#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7002

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/identity/host/abpTemp.IdentityService.HttpApi.Host/abpTemp.IdentityService.HttpApi.Host.csproj", "services/identity/host/abpTemp.IdentityService.HttpApi.Host/"]
COPY ["shared/abpTemp.Hosting.Shared/abpTemp.Hosting.Shared.csproj", "shared/abpTemp.Hosting.Shared/"]
COPY ["services/administration/src/abpTemp.Administration.EntityFrameworkCore/abpTemp.Administration.EntityFrameworkCore.csproj", "services/administration/src/abpTemp.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/abpTemp.Administration.Domain/abpTemp.Administration.Domain.csproj", "services/administration/src/abpTemp.Administration.Domain/"]
COPY ["services/administration/src/abpTemp.Administration.Domain.Shared/abpTemp.Administration.Domain.Shared.csproj", "services/administration/src/abpTemp.Administration.Domain.Shared/"]
COPY ["services/saas/src/abpTemp.SaaS.EntityFrameworkCore/abpTemp.SaaS.EntityFrameworkCore.csproj", "services/saas/src/abpTemp.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain/abpTemp.SaaS.Domain.csproj", "services/saas/src/abpTemp.SaaS.Domain/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain.Shared/abpTemp.SaaS.Domain.Shared.csproj", "services/saas/src/abpTemp.SaaS.Domain.Shared/"]
COPY ["services/identity/src/abpTemp.IdentityService.HttpApi/abpTemp.IdentityService.HttpApi.csproj", "services/identity/src/abpTemp.IdentityService.HttpApi/"]
COPY ["services/identity/src/abpTemp.IdentityService.Application.Contracts/abpTemp.IdentityService.Application.Contracts.csproj", "services/identity/src/abpTemp.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain.Shared/abpTemp.IdentityService.Domain.Shared.csproj", "services/identity/src/abpTemp.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/abpTemp.IdentityService.Application/abpTemp.IdentityService.Application.csproj", "services/identity/src/abpTemp.IdentityService.Application/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain/abpTemp.IdentityService.Domain.csproj", "services/identity/src/abpTemp.IdentityService.Domain/"]
COPY ["services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/abpTemp.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/"]
RUN dotnet restore "services/identity/host/abpTemp.IdentityService.HttpApi.Host/abpTemp.IdentityService.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/identity/host/abpTemp.IdentityService.HttpApi.Host"
RUN dotnet build "abpTemp.IdentityService.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "abpTemp.IdentityService.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "abpTemp.IdentityService.HttpApi.Host.dll"]