FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SW.Gds.Web/SW.Gds.Web.csproj", "SW.Gds.Web/"]
COPY ["SW.Gds.Sdk/SW.Gds.Sdk.csproj", "SW.Gds.Sdk/"]
COPY ["SW.Gds.Util/SW.Gds.Util.csproj", "SW.Gds.Util/"]

RUN dotnet restore "SW.Gds.Web/SW.Gds.Web.csproj"
COPY . .
WORKDIR "/src/SW.Gds.Web"
RUN dotnet build "SW.Gds.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SW.Gds.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "SW.Gds.Web.dll"]
 
