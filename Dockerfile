# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY IntSequenceString/*.csproj IntSequenceString/
RUN dotnet restore IntSequenceString/IntSequenceString.csproj

# copy and build app and libraries
COPY IntSequenceString/ IntSequenceString/
WORKDIR /source/IntSequenceString
RUN dotnet build -c release --no-restore

# test stage -- exposes optional entrypoint
# target entrypoint with: docker build --target test
FROM build AS test
WORKDIR /source/tests
COPY IntSequenceString.Tests/ .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]