FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OptimalCuts/OptimalCuts.csproj", "OptimalCuts/"]
RUN dotnet restore "OptimalCuts/OptimalCuts.csproj"
COPY . .
WORKDIR "/src/OptimalCuts"
RUN dotnet build "OptimalCuts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OptimalCuts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OptimalCuts.dll"]
