#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Week6Capstone/Week6Capstone.csproj", "Week6Capstone/"]
RUN dotnet restore "Week6Capstone/Week6Capstone.csproj"
COPY . .
WORKDIR "/src/Week6Capstone"
RUN dotnet build "Week6Capstone.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Week6Capstone.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Week6Capstone.dll"]