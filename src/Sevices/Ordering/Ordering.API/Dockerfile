#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Sevices/Ordering/Ordering.API/Ordering.API.csproj", "Sevices/Ordering/Ordering.API/"]
COPY ["Sevices/Ordering/Ordering.Application/Ordering.Application.csproj", "Sevices/Ordering/Ordering.Application/"]
COPY ["Sevices/Ordering/Ordering.Domain/Ordering.Domain.csproj", "Sevices/Ordering/Ordering.Domain/"]
COPY ["Sevices/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Sevices/Ordering/Ordering.Infrastructure/"]
RUN dotnet restore "Sevices/Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/Sevices/Ordering/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]
