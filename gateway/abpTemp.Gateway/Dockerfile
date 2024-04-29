#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 7500

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["gateway/abpTemp.Gateway/abpTemp.Gateway.csproj", "gateway/abpTemp.Gateway/"]
RUN dotnet restore "gateway/abpTemp.Gateway/abpTemp.Gateway.csproj"
COPY . .
WORKDIR "/src/gateway/abpTemp.Gateway"
RUN dotnet build "abpTemp.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "abpTemp.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#does nto work even if it is the same cert
COPY ["apps/abpTemp.AuthServer/certificates/aspnetapp.pfx", "aspnetapp.pfx"]
#COPY ["apps/abpTemp.AuthServer/certificates/aspnetapp.pfx", "/usr/local/share/ca-certificates/aspnetapp.crt"]
#RUN chmod 644 /usr/local/share/ca-certificates/aspnetapp.crt \
    #&& update-ca-certificates
ENTRYPOINT ["dotnet", "abpTemp.Gateway.dll"]