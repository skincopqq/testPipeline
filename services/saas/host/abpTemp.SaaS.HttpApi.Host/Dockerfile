#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 7003


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/abpTemp.SaaS.HttpApi.Host/abpTemp.SaaS.HttpApi.Host.csproj", "services/saas/host/abpTemp.SaaS.HttpApi.Host/"]
COPY ["shared/abpTemp.Hosting.Shared/abpTemp.Hosting.Shared.csproj", "shared/abpTemp.Hosting.Shared/"]
COPY ["services/administration/src/abpTemp.Administration.EntityFrameworkCore/abpTemp.Administration.EntityFrameworkCore.csproj", "services/administration/src/abpTemp.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/abpTemp.Administration.Domain/abpTemp.Administration.Domain.csproj", "services/administration/src/abpTemp.Administration.Domain/"]
COPY ["services/administration/src/abpTemp.Administration.Domain.Shared/abpTemp.Administration.Domain.Shared.csproj", "services/administration/src/abpTemp.Administration.Domain.Shared/"]
COPY ["services/saas/src/abpTemp.SaaS.HttpApi/abpTemp.SaaS.HttpApi.csproj", "services/saas/src/abpTemp.SaaS.HttpApi/"]
COPY ["services/saas/src/abpTemp.SaaS.Application.Contracts/abpTemp.SaaS.Application.Contracts.csproj", "services/saas/src/abpTemp.SaaS.Application.Contracts/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain.Shared/abpTemp.SaaS.Domain.Shared.csproj", "services/saas/src/abpTemp.SaaS.Domain.Shared/"]
COPY ["services/saas/src/abpTemp.SaaS.Application/abpTemp.SaaS.Application.csproj", "services/saas/src/abpTemp.SaaS.Application/"]
COPY ["services/saas/src/abpTemp.SaaS.Domain/abpTemp.SaaS.Domain.csproj", "services/saas/src/abpTemp.SaaS.Domain/"]
COPY ["services/saas/src/abpTemp.SaaS.EntityFrameworkCore/abpTemp.SaaS.EntityFrameworkCore.csproj", "services/saas/src/abpTemp.SaaS.EntityFrameworkCore/"]
RUN dotnet restore "services/saas/host/abpTemp.SaaS.HttpApi.Host/abpTemp.SaaS.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/abpTemp.SaaS.HttpApi.Host"
RUN dotnet build "abpTemp.SaaS.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "abpTemp.SaaS.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["apps/abpTemp.AuthServer/certificates/aspnetapp.pfx", "aspnetapp.pfx"]
ENTRYPOINT ["dotnet", "abpTemp.SaaS.HttpApi.Host.dll"]