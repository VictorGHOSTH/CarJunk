FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["CarJunk/CarJunk.csproj", "CarJunk/"]
RUN dotnet restore "CarJunk/CarJunk.csproj"
COPY . .
WORKDIR "/src/CarJunk"
RUN dotnet publish "CarJunk.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:10000
ENTRYPOINT ["dotnet", "CarJunk.dll"]