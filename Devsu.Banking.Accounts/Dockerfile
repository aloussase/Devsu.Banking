FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY Devsu.Banking.Accounts.csproj .
RUN dotnet restore Devsu.Banking.Accounts.csproj

COPY . .
RUN dotnet build Devsu.Banking.Accounts.csproj -c Release -o /app/build

FROM build AS publish
WORKDIR /src
RUN dotnet publish Devsu.Banking.Accounts.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

ENV PORT=5001
EXPOSE ${PORT}

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Devsu.Banking.Accounts.dll"]