#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Categories.API/Categories.API.csproj", "Categories.API/"]
RUN dotnet restore "Categories.API/Categories.API.csproj"
COPY . .
WORKDIR "/src/Categories.API"
RUN dotnet build "Categories.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Categories.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Categories.API.dll"]