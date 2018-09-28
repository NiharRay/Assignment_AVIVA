Feature: GoogleSearchFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@GoogleSearch
Scenario Outline: Finding 5th search result of a given keyword
	Given I have google engine configured
	When I provide <SEARCHKEYWORD> keyword to search
	Then I should get 5th result url

	Examples: 
	| SEARCHKEYWORD |
	| TCS           |
	| AVIVA         |
	| specflow      |

@GoogleSearch
Scenario: Finding 5th search result of a given null keyword
	Given I have google engine configured
	When I provide null keyword to search
	Then I should get 5th result url

