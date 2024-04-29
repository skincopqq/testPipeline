#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 7001


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/host/abpTemp.Administration.HttpApi.Host/abpTemp.Administration.HttpApi.Host.csproj", "services/administration/host/abpTemp.Administration.HttpApi.Host/"]
COPY ["shared/abpTemp.Hosting.Shared/abpTemp.Hosting.Shared.csproj", "shared/abpTemp.Hosting.Shared/"]
COPY ["services/identity/src/abpTemp.IdentityService.Application.Contracts/abpTemp.IdentityService.Application.Contracts.csproj", "services/identity/src/abpTemp.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain.Shared/abpTemp.IdentityService.Domain.Shared.csproj", "services/identity/src/abpTemp.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/abpTemp.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/abpTemp.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/abpTemp.IdentityService.Domain/abpTemp.IdentityService.Domain.csproj", "services/identity/src/abpTemp.IdentityService.Domain/"]
COPY ["services/saas/src/abpTemp.SaaS.Application.Contracts/abpTemp.SaaS.Application.Contracts.csproj", "services/saas/src/abpTemp.SaaS.Application.Contracts/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain.Shared/abpTemp.SaaS.Domain.Shared.csproj", "services/saas/src/abpTemp.SaaS.Domain.Shared/"]
COPY ["services/administration/src/abpTemp.Administration.HttpApi/abpTemp.Administration.HttpApi.csproj", "services/administration/src/abpTemp.Administration.HttpApi/"]
COPY ["services/administration/src/abpTemp.Administration.Application.Contracts/abpTemp.Administration.Application.Contracts.csproj", "services/administration/src/abpTemp.Administration.Application.Contracts/"]
COPY ["services/administration/src/abpTemp.Administration.Domain.Shared/abpTemp.Administration.Domain.Shared.csproj", "services/administration/src/abpTemp.Administration.Domain.Shared/"]
COPY ["services/administration/src/abpTemp.Administration.Application/abpTemp.Administration.Application.csproj", "services/administration/src/abpTemp.Administration.Application/"]
COPY ["services/administration/src/abpTemp.Administration.Domain/abpTemp.Administration.Domain.csproj", "services/administration/src/abpTemp.Administration.Domain/"]
COPY ["services/administration/src/abpTemp.Administration.EntityFrameworkCore/abpTemp.Administration.EntityFrameworkCore.csproj", "services/administration/src/abpTemp.Administration.EntityFrameworkCore/"]
RUN dotnet restore "services/administration/host/abpTemp.Administration.HttpApi.Host/abpTemp.Administration.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/administration/host/abpTemp.Administration.HttpApi.Host"
RUN dotnet build "abpTemp.Administration.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "abpTemp.Administration.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["apps/abpTemp.AuthServer/certificates/aspnetapp.pfx", "certificates/aspnetapp.pfx"]
ENTRYPOINT ["dotnet", "abpTemp.Administration.HttpApi.Host.dll"]