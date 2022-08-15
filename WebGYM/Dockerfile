#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebGYM/WebGYM.csproj", "WebGYM/"]
RUN dotnet restore "WebGYM/WebGYM.csproj"
COPY . .
WORKDIR "/src/WebGYM"
RUN dotnet build "WebGYM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebGYM.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebGYM.dll"]