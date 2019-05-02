Feature: Search on Google.com
	I want to preform a search on Google on my next holidays destination

Scenario Outline: Looking for a travel destination
	Given I navigate to Google
	When I insert the text '<Country>' in the search box 
	And I click on the key Enter
	And I am on the search result page
	Then I would like to take screenshot '<Country>'
Examples: 
| Country  |
| Bahamas  |
| New York |

		