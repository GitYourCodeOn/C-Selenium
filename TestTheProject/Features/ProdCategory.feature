@Testplan2
Feature: ProdCategory
	As a user I want to select the ‘Summer Dresses’ option from the navigation menu, 
	so that I can view an item from the summer collection

@Testplan2a
Scenario: Women summer dresses categroy
	Given I am on the automationpractice homepage
	And I Hover over the WOMAN category and assert subnavigation options
	When I click the Summer dresses button on WOMAN sub-navigation 
	Then Only summer items are displayed inside the search results