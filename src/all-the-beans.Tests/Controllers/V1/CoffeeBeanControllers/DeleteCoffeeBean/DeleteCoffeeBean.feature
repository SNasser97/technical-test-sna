Feature: V1 - DeleteCoffeeBean

# Happy Scenario - Validate only specified CoffeeBean was deleted
Scenario Outline: Request Successful - CoffeeBean Deleted - 204 No Content
	Given the request url contains Id field with <coffeebean-to-delete-Id>
	And a CoffeeBean exists with Id <coffeebean-to-delete-Id>
	And another CoffeeBean exists with Id <coffeebean-not-to-delete-Id>
	When a DELETE request is made
	Then the response was 204 NoContent
	And the CoffeeBean with Id <coffeebean-to-delete-Id> was deleted
	And the CoffeeBean with Id <coffeebean-not-to-delete-Id> was not deleted

	Examples:
	| coffeebean-to-delete-Id  | coffeebean-not-to-delete-Id |
	| c4ca4238a0b923820dcc509a | eccbc87e4b5ce2fe28308fd9	 |

# Negative Scenario - malformed Id
Scenario: Request Failure - CoffeeBean Not Found - Invalid RequestUrl Id Supplied
	Given the request url contains Id field with <invalid-request-id>
	When a DELETE request is made
	Then the response was 400 Bad Request

	Examples:
	| invalid-request-id					|
	| invalid_value							|
	| 00000000-0000-0000-0000-000000000000	|

# Other scenarios to consider - CoffeeBean not found