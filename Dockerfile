#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY "CarAssistance.sln" "CarAssistance.sln"

COPY "Shared.Contracts/Shared.Contracts.csproj" "Shared.Contracts/Shared.Contracts.csproj"
COPY "CarAssistance/CarAssistance.csproj" "CarAssistance/CarAssistance.csproj"
COPY "ExportDataFromExcel/ExportDataFromExcel.csproj" "ExportDataFromExcel/ExportDataFromExcel.csproj"

RUN dotnet restore "CarAssistance.sln"

COPY . .
WORKDIR /src/CarAssistance
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CarAssistance.dll"]
