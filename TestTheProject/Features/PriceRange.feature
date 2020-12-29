@Testplan3
Feature: PriceRange
	As a user when searching for a summer dress, 
	I want to change the price range to $16 - $20 
	so that I see the search results change

@Testplan3a
Scenario: Search price range so results match my buidget
	Given I have navigated to the dresses page
	When I select the price range to be between $16-$30 
	Then I should see results that match my budget in the search results