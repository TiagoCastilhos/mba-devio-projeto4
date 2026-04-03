FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
EXPOSE 8080

# Copy csproj and restore as distinct layers
COPY Coldmart.sln Coldmart.sln
COPY src/Coldmart.BFF/Coldmart.BFF.csproj src/Coldmart.BFF/Coldmart.BFF.csproj

# Restore package deps
RUN dotnet restore src/Coldmart.BFF/Coldmart.BFF.csproj

# Copy everything else and build
COPY . .
WORKDIR ./src/Coldmart.BFF
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Coldmart.BFF.dll"]
