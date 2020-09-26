FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app


#�������� .cproj � ��������������� ����� ������
COPY *.sln .
COPY CarAssistance/*.csproj ./CarAssistance/
COPY Shared.Contracts/*.csproj ./Shared.Contracts/
COPY ExportDataFromExcel/*.csproj ./ExportDataFromExcel/
WORKDIR /app/CarAssistance
RUN dotnet restore


#�������� �� ����� �������� ����������
WORKDIR /app/
COPY CarAssistance/. ./CarAssistance/
COPY Shared.Contracts/. ./Shared.Contracts/
COPY ExportDataFromExcel/. ./ExportDataFromExcel/
WORKDIR /app/CarAssistance
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app/CarAssistace/out ./
ENTRYPOINT ["dotnet", "carassistance.dll"]
