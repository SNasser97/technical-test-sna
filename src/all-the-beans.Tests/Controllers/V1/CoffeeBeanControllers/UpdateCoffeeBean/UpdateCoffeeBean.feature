Feature: V1 - UpdateCoffeeBean

# Happy Scenario
Scenario: Request Successful - CoffeeBean Created - 200 OK
	Given the request url contains Id field with <coffee-bean-update-Id>
	And a CoffeeBean exists with Id <coffee-bean-update-Id>
	And the request body contains a valid Name
	And the request body contains a valid Country
	And the request body contains a valid Colour
	And the request body contains a valid Cost
	And the request body contains a valid Description
	And the request body contains a valid Image
	When a PUT request is made
	Then the response was 200 OK
	And the CoffeeBean was updated for Id <coffee-bean-update-Id>
	And the updated CoffeeBean Name matches the request body field Name
	And the updated CoffeeBean Country matches the request body field Country
	And the updated CoffeeBean Colour matches the request body field Colour
	And the updated CoffeeBean Cost matches the request body field Cost
	And the updated CoffeeBean Description matches the request body field Description
	And the updated CoffeeBean Image matches the request body field Image

	Examples: 
	| coffee-bean-update-Id    |
	| d41d8cd98f00b204e9800998 |

# Negative Scenario - malformed Id
Scenario: Request Failure - CoffeeBean Not Found - Invalid RequestUrl Id Supplied
	Given the request url contains Id field with <invalid-request-id>
	And the request body contains a valid Name
	And the request body contains a valid Country
	And the request body contains a valid Colour
	And the request body contains a valid Cost
	And the request body contains a valid Description
	And the request body contains a valid Image
	When a PUT request is made
	Then the response was 400 Bad Request

	Examples:
	| invalid-request-id					|
	| invalid_value							|
	| 00000000-0000-0000-0000-000000000000	|

# Other scenarios to consider - CoffeeBean not found
