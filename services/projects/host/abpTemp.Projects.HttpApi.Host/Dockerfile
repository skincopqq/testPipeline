#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["services/projects/NuGet.Config", "services/projects/"]
COPY ["services/projects/host/abpTemp.Projects.HttpApi.Host/abpTemp.Projects.HttpApi.Host.csproj", "services/projects/host/abpTemp.Projects.HttpApi.Host/"]
COPY ["services/projects/src/abpTemp.Projects.HttpApi/abpTemp.Projects.HttpApi.csproj", "services/projects/src/abpTemp.Projects.HttpApi/"]
COPY ["services/projects/src/abpTemp.Projects.Application.Contracts/abpTemp.Projects.Application.Contracts.csproj", "services/projects/src/abpTemp.Projects.Application.Contracts/"]
COPY ["services/projects/src/abpTemp.Projects.Domain.Shared/abpTemp.Projects.Domain.Shared.csproj", "services/projects/src/abpTemp.Projects.Domain.Shared/"]
COPY ["services/projects/src/abpTemp.Projects.Application/abpTemp.Projects.Application.csproj", "services/projects/src/abpTemp.Projects.Application/"]
COPY ["services/projects/src/abpTemp.Projects.Domain/abpTemp.Projects.Domain.csproj", "services/projects/src/abpTemp.Projects.Domain/"]
COPY ["services/projects/src/abpTemp.Projects.EntityFrameworkCore/abpTemp.Projects.EntityFrameworkCore.csproj", "services/projects/src/abpTemp.Projects.EntityFrameworkCore/"]
RUN dotnet restore "services/projects/host/abpTemp.Projects.HttpApi.Host/abpTemp.Projects.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/projects/host/abpTemp.Projects.HttpApi.Host"
RUN dotnet build "abpTemp.Projects.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "abpTemp.Projects.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["apps/abpTemp.AuthServer/certificates/aspnetapp.pfx", "aspnetapp.pfx"]
ENTRYPOINT ["dotnet", "abpTemp.Projects.HttpApi.Host.dll"]