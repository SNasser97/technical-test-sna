Feature: V1 - GetCoffeeBeans

# Happy Scenario - Default Page: 1, Default ItemsPerPage: 25
Scenario: Request Successful - CoffeeBeans Returned - 200 OK
	Given 30 CoffeeBeans exist
	When a GET request is made
	Then the response was 200 OK
	And the response contains 25 items

# Happy Scenario - Page: 1, ItemsPerPage: 10
Scenario: Request Successful - Custom Pagination Supplied - CoffeeBeans Returned - 200 OK
	Given the request url contains query parameter Page with value 1
	And the request url contains query parameter ItemsPerPage with value 10
	And 30 CoffeeBeans exist
	When a GET request is made
	Then the response was 200 OK
	And the response contains 10 items

Scenario: Request Successful - CoffeeBeans Returned Empty - 200 OK
	Given 0 CoffeeBeans exist
	When a GET request is made
	Then the response was 200 OK
	And the response was empty

# Happy Scenario - Page: 1, ItemsPerPage: 10
Scenario Outline: Request Successful - Custom Query Parameter - CoffeeBeans Returned - 200 OK
	Given the request url contains query parameter Page with value 1
	And the request url contains query parameter ItemsPerPage with value 25
	And the request url contains query parameter <filter> with value <value>
	And 5 CoffeeBeans exist with Colour Chocolate Brown
	And 25 CoffeeBeans exist
	When a GET request is made
	Then the response was 200 OK
	And the response contains 5 items

	Examples: 
	| filter | value       |
	| Colour | Chocolate   |
# Additional scenarios to consider - Validating Page and ItemsPerPage, clamping values