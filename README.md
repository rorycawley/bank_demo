# bank_demo

# Create the solution

dotnet new sln -o ShoppingCart
cd ShoppingCart

# Create Core Projects

## Core Domain Project (class library)

dotnet new classlib -o src/Core
dotnet sln add src/Core/Core.csproj

# Create Adapters Projects

## Web API (FastEndpoints) Project

dotnet new web -o src/Adapters/WebApi
dotnet sln add src/Adapters/WebApi/WebApi.csproj

## Console App Project

dotnet new console -o src/Adapters/ConsoleApp
dotnet sln add src/Adapters/ConsoleApp/ConsoleApp.csproj

# Create Test Projects

## Unit Test Project (xUnit)

dotnet new xunit -o tests/UnitTests
dotnet sln add tests/UnitTests/UnitTests.csproj

## Integration Test Project (xUnit)

dotnet new xunit -o tests/IntegrationTests
dotnet sln add tests/IntegrationTests/IntegrationTests.csproj

## System Test Project (xUnit)

dotnet new xunit -o tests/SystemTests
dotnet sln add tests/SystemTests/SystemTests.csproj

# Project Dependencies

## WebApi and ConsoleApp reference Core

dotnet add src/Adapters/WebApi/WebApi.csproj reference src/Core/Core.csproj
dotnet add src/Adapters/ConsoleApp/ConsoleApp.csproj reference src/Core/Core.csproj

## Test projects reference Core and adapters

dotnet add tests/UnitTests/UnitTests.csproj reference src/Core/Core.csproj
dotnet add tests/IntegrationTests/IntegrationTests.csproj reference src/Core/Core.csproj
dotnet add tests/SystemTests/SystemTests.csproj reference src/Adapters/WebApi/WebApi.csproj
dotnet add tests/SystemTests/SystemTests.csproj reference src/Adapters/ConsoleApp/ConsoleApp.csproj

# Install Required NuGet Packages

## For FastEndpoints (WebApi):

dotnet add src/Adapters/WebApi/WebApi.csproj package FastEndpoints

## For FluentAssertions & Moq (testing):

dotnet add tests/UnitTests/UnitTests.csproj package FluentAssertions
dotnet add tests/UnitTests/UnitTests.csproj package Moq

dotnet add tests/IntegrationTests/IntegrationTests.csproj package FluentAssertions
dotnet add tests/SystemTests/SystemTests.csproj package FluentAssertions

# Build and Verify Setup

dotnet build
