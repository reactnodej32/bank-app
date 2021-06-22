# Development Mode
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:5.0.103 AS build
WORKDIR /src
COPY ["bankapp.csproj", "./"]
RUN dotnet restore "./bankapp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "bankapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bankapp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "bankapp.dll"]
