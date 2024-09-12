FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY Devsu.Banking.Clients.csproj .
RUN dotnet restore Devsu.Banking.Clients.csproj

COPY . .
RUN dotnet build Devsu.Banking.Clients.csproj -c Release -o /app/build

FROM build AS publish
WORKDIR /src
RUN dotnet publish Devsu.Banking.Clients.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

ENV PORT=5000
EXPOSE ${PORT}

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Devsu.Banking.Clients.dll"]