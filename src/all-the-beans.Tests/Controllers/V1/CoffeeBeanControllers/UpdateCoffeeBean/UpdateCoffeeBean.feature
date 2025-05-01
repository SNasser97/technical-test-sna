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
	When a PUT request is made
	Then the response was 200 OK
	And the CoffeeBean was updated
	And the updated CoffeeBean Name matches the request body field Name
	And the updated CoffeeBean Country matches the request body field Country
	And the updated CoffeeBean Colour matches the request body field Colour
	And the updated CoffeeBean Cost matches the request body field Cost
	And the updated CoffeeBean Description matches the request body field Description

	Examples: 
	| coffee-bean-update-Id         |
	| e99a18c428cb38d5f260853678922 |