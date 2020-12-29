@Test#plan1
Feature: Basket
	As a user if there is an item already inside my basket, 
	I want to be able to delete the item from the basket page 
	so that I can see the basket is empt

Background: 
Given item has been added to cart

@TestPlan1a
Scenario: Shopping cart items can be deleted
	Given An item exists in my basket
	And Im able to see the delete button 
	When I select the delete button
	Then the banner must display Your shopping Cart is Empty