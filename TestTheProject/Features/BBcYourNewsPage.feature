Feature: BBcYourAccountPage
	

@mytag
Scenario: Navigate to the account Page and back
	Given I am on the homePage
	When I click the Account button
	Then I am navigated to the Account Page
	And Then navigated back to the HomePage by clicking the homepage button
