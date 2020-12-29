@Testplan5
Feature: OurStoresPage
	 As a user when browsing the ‘Our stores’ page, 
	 I want to drag the map to see a store from West Palm Beach,
	 so that I can take a screenshot for future reference. 

@Testplan5a
	Scenario: Navigate to the OUR STORES Page and take a screenshot of locations near palm beach
	Given I navigate to the Our Stores web page
	And I scroll through the map 
	When I search 'West Palm Beach' 
	Then I'm able to find stores nearby for me to take a screenshot