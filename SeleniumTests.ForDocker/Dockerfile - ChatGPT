# Use the .NET 8.0 SDK image as the base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
	
# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.sln .
COPY SeleniumTests.ForDocker/*.csproj ./SeleniumTests.ForDocker/

RUN dotnet restore

# Copy the entire project and build it
COPY . .
RUN dotnet build -c Release --no-restore

# Run the tests using NUnit
RUN dotnet test --no-build --logger "console;verbosity=detailed"
