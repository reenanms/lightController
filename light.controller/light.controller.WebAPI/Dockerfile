#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["light.controller.WebAPI/light.controller.WebAPI.csproj", "light.controller.WebAPI/"]
RUN dotnet restore "light.controller.WebAPI/light.controller.WebAPI.csproj"
COPY . .
WORKDIR "/src/light.controller.WebAPI"
RUN dotnet build "light.controller.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "light.controller.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "light.controller.WebAPI.dll"]