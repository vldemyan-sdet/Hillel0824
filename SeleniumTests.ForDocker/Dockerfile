# Use the .NET 8.0 SDK image as the base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN apt-get update && \
    apt-get install -y --no-install-recommends gnupg wget curl unzip && \
    wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    echo "deb http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google.list && \
    apt-get update -y && \
    apt-get install -y --no-install-recommends google-chrome-stable && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/* /var/cache/apt/*
	
# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.sln .
COPY SeleniumTests.ForDocker/*.csproj ./SeleniumTests.ForDocker/

RUN dotnet restore

# Copy the entire project and build it
COPY . .
RUN dotnet build -c Release --no-restore

#ADD ./screenshots /app/SeleniumTests.ForDocker/bin/Release/net8.0/screenshots

# Run the tests using NUnit
# RUN dotnet test -c Release --no-build --logger "console;verbosity=detailed"
ENTRYPOINT ["dotnet", "test", "-c", "Release", "--no-build", "--logger", "trx;LogFilePrefix=ForDocker"]

# docker build -t selenium-nunit-tests2 .
# docker run --rm -it -v ${PWD}/screenshots:/app/SeleniumTests.ForDocker/bin/Release/net8.0/screenshots -v ${PWD}/testresults:/app/SeleniumTests.ForDocker/TestResults selenium-nunit-tests2