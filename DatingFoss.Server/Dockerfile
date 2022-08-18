FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5202

ENV ASPNETCORE_URLS=http://+:5202

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["DatingFoss.Server/DatingFoss.Server.csproj", "DatingFoss.Server/"]
RUN dotnet restore "DatingFoss.Server/DatingFoss.Server.csproj"
COPY . .
WORKDIR "/src/DatingFoss.Server"
RUN dotnet build "DatingFoss.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DatingFoss.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatingFoss.Server.dll"]
