# technical-test-sna

# About
Simple .NET WebAPI CRUD operations against CoffeeBeans
Using .NET Core 8

Included GithubActions for simple CI/CD which builds and runs defined tests in the project.

## Packages used:
- Entity Framework Core 8 - for database access/ORM purposes
- Entity Framework Design - for design time database access (migration management and scaffolding)
- Microsoft.Extensions.Configuration - for configuration management (building extension methods in project)
- Pomelo.EntityFrameworkCore.MySql - extension package from EF Core for MySql database access
- TestContainers.MySql - Allowing for simple MySql database creation and teardown
- Reqnroll.NUnit (Specflow replacement due to Specflow being deprecated)
- NUnit - for assertions and possible unit testing in future (used for assertions in integration/bdd tests..)
- Microsoft.AspNetCore.Mvc.Testing - for integration testing

# Getting Started
## Prerequisites:
- .NET Core 8 SDK
- Docker
- Postman or any other API Test tool
- MySQL WorkBench (Or view from phpmyadmin container once this is running - see Steps for running locally)

## Steps for running locally:
1. Clone the repository
1. Open the solution in your IDE of choice (Visual Studio, Rider, etc.)
1. Build the solution
1. Run `docker compose up -d` to start the MySql database
1. Ensure Mysql container and relevant containers are up and running
1. Visit http://localhost:8081 to view database in phpmyadmin
1. Run the application using `dotnet run` or from your IDE
1. The API should be available at https://localhost:7280 if IDE is selected to run with https or http://localhost:5053 if running http.
1. To view endpoint documentation visit: (Running HTTPS) https://localhost:7280/swagger/index.html or (Running HTTP) http://localhost:5053/swagger/index.html  
1. For interacting with endpoints a Postman collection is available in the project with local environment variables. See folder 'postman-collection'

# Considerations:
1. Cross-cutting concerns: logging, authentication, authorisation
1. Security: Ratelimiting, authorisation/authentication (who can interact with these endpoints, who has access to perform operations..)
1. Concurrency: performing update to a potentially deleted coffeebean record, handling conflicts
1. Idempotency - retrying requests e.g. POST requests and ensuring state has not been modified
1. Validations - stripping html tags from certain fields, image url validations
1. Caching - fetching coffeebeans, initial requests should be DB hits but any further requests with same parameters should return from cache - performance
1. Environment variables per environment: local environments, staging, production etc...
1. Load testing: if expanding on this in other environments then load testing endpoints to gather metrics
1. Unit testing (currently BDD tests which are integration tests between API -> Logic -> Data interaction)
1. Filtering/searching capabilities: utilise Elasticsearch for complex filtering a long with OData filters example: retrieving price between 5 and 10