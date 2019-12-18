Feature: BBcPageNavTest
	

@mytag
Scenario: BBc Page
	Given I am on the BBc HomePage
	When Inavigate to the Sports section
	And Click the homeepage button 
	Then I am navigated back to the homepage
