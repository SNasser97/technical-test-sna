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
1. Build the solution:
```bash
dotnet build
```
1. Run docker containers to start the MySql database and phpmyadmin. The docker-compose.yml file is located outside the `src/` folder.
```bash
docker-compose up
```
1. Ensure Mysql container and relevant containers are up and running
1. Once service is running migration scripts should have been applied to generate the database and CoffeeBean table
<br><br> Note: **Running the service will seed test data supplied from AllTheBeans.json file located in `src/all-the-beans.Data/Utilities/`**

1. Visit http://localhost:8081 to view database in phpmyadmin
1. Run the application using (or Run from your IDE):
```bash
dotnet run --project src/all-the-beans.Api/all-the-beans.Api.csproj
```
1. The API should be available at https://localhost:7280 if IDE is selected to run with https or http://localhost:5053 if running http.
1. To view endpoint documentation visit: (Running HTTPS) https://localhost:7280/swagger/index.html or (Running HTTP) http://localhost:5053/swagger/index.html  
1. For interacting with endpoints a Postman collection is available to import. See folder 'postman-collection'
1. For running tests this can be run from IDE. These tests run against an isolated MySql container created by TestContainer
<br><br>Or run the following command in the terminal (ensure you are in the `src/` folder first before running`):
```bash
dotnet test
```

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
1. Cancellation tokens: possibly using these for long running tasks or if for some reason client cancels the request (closing browser)

# Testing GET BeanOfTheDay
1. Ensure service is running (follow steps above)
1. When running the service some data will be seeded
1. One of the coffeebeans will be already a BeanOfTheDay with a timestamp set to 24 hours ago
1. Use Postman to send a GET request to the endpoint: `https://localhost:7280/v1/api/coffeebeans/bean-of-the-day` or `http://localhost:5053/v1/api/coffeebeans/bean-of-the-day`
1. The response should then return a random Coffeebean from the database
1. Any further responses should keep returning the same Coffeebean until the 24 hours has passed
1. To test if a new random CoffeeBean is selected can edit the timestamp in phpmyadmin or MySQL WorkBench 
	1. Note: The timestamp is represented in miliseconds
	1. Resource: Can use https://www.epochconverter.com/

# Updating CoffeeBeanTable

**Ensure MySQL container is running** <br><br>
Any changes to CoffeeBean table will require a migration script to be created and applied to the database. <br><br> This can be done by running the following command in the terminal:
```bash
dotnet ef migrations add <your-migration-script-name> --project src/all-the-beans.Data/all-the-beans.Data.csproj --startup-project src/all-the-beans.Api/all-the-beans.Api.csproj
```

Then run the service which should apply this.

Alternatively apply the migration in the CLI:
```bash
dotnet ef migrations update --project src/all-the-beans.Data/all-the-beans.Data.csproj --startup-project src/all-the-beans.Api/all-the-beans.Api.csproj
```