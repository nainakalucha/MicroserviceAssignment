FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52563
EXPOSE 44394

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AggregatorApi/AggregatorApi.csproj", "AggregatorApi/"]
RUN dotnet restore "AggregatorApi/AggregatorApi.csproj"
COPY . .
WORKDIR "/src/AggregatorApi"
RUN dotnet build "AggregatorApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AggregatorApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AggregatorApi.dll"]