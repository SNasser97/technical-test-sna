Feature: V1 - CreateCoffeeBean

# Happy Scenario
Scenario: Request Successful - CoffeeBean Created - 201 Created
	Given the request body contains a valid Name
	And the request body contains a valid Country
	And the request body contains a valid Colour
	And the request body contains a valid Cost
	And the request body contains a valid Description
	When a POST request is made
	Then the response was 201 Created
	And the new CoffeeBean was created
	And the new CoffeeBean Name matches the request body field Name
	And the new CoffeeBean Country matches the request body field Country
	And the new CoffeeBean Colour matches the request body field Colour
	And the new CoffeeBean Cost matches the request body field Cost
	And the new CoffeeBean Description matches the request body field Description

# Negative Scenarios - Scenarios usually tend to cover validating the request fields/business logic etc..
# Example - 409 Conflict (If another CoffeeBean with Name exists..), 400 (If any mandatory fields are missing..)
