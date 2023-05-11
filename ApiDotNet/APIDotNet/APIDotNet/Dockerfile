#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["APIDotNet/APIDotNet.csproj", "APIDotNet/"]
RUN dotnet restore "APIDotNet/APIDotNet.csproj"
COPY . .
WORKDIR "/src/APIDotNet"
RUN dotnet build "APIDotNet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIDotNet.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIDotNet.dll"]