#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebGYM/WebAPI.csproj", "WebGYM/"]
COPY ["WebGYM.Application/WebGYM.Application.csproj", "WebGYM.Application/"]
COPY ["WebGYM.Domain/WebGYM.Domain.csproj", "WebGYM.Domain/"]
COPY ["WebGYM.Persistance/WebGYM.Persistance.csproj", "WebGYM.Persistance/"]
RUN dotnet restore "WebGYM/WebAPI.csproj"
COPY . .
WORKDIR "/src/WebGYM"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]