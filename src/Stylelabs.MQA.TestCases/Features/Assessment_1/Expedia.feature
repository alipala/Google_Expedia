Feature: Expedia Test 
	I want to perform a search on Expedia  


Scenario: Look for a flight and accomadation on Expedia
	Given I navigate to the Expedia website
	When I look for a flight-accomadation from Brussels to New York
	And I click on the key Search
	Then the result page contains travel option from the chosen destination
