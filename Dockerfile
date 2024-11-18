# Use the official .NET 8 SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set working directory
WORKDIR /app

# Copy the entire project and build it
COPY . ./
RUN dotnet build
RUN dotnet publish ./TestingApiService.sln -o ./publish

# Run the Playwright tests
ENTRYPOINT ["dotnet", "publish/TestingApiService.dll"]