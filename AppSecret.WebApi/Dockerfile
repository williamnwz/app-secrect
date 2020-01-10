#FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
#WORKDIR /src
#COPY ["AppSecret.WebApi/AppSecret.WebApi.csproj", "AppSecret.WebApi/"]
#RUN dotnet restore "AppSecret.WebApi/AppSecret.WebApi.csproj"
#COPY . .
#WORKDIR "/src/AppSecret.WebApi"
#RUN dotnet build "AppSecret.WebApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "AppSecret.WebApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AppSecret.WebApi.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build

COPY .
WORKDIR /src
COPY ["AppSecret.WebApi/AppSecret.WebApi.csproj", "AppSecret.WebApi/"]
RUN dotnet restore "AppSecret.WebApi/AppSecret.WebApi.csproj"
COPY . .
WORKDIR "/src/AppSecret.WebApi"
RUN dotnet build "AppSecret.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppSecret.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppSecret.WebApi.dll"]