FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY ./rinha-backend-api/*.csproj ./

RUN dotnet restore

COPY ./rinha-backend-api ./

RUN dotnet publish -c Release

ENTRYPOINT [ "dotnet", "./bin/Release/net7.0/rinha-backend-api.dll" ]
